using System.Linq.Expressions;
using System.Security.Claims;
using API.Belvo.Models;
using API.Belvo.Persistence;
using API.Belvo.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Workcube.Interfaces;
using Workcube.Libraries;
using Workcube.ViewModels;

namespace API.Belvo.Services
{
    public class TransaccionesService : IGlobal<Transaccion>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public TransaccionesService(Context context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public Task Create(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task Create(dynamic data)
        {
            using var objTransaction = _context.Database.BeginTransaction();
            try
            {
                Transaccion objModel = new Transaccion
                {
                    IdTransaccion                       = data.id,
                    IdCuenta                            = data.account?.id              ?? "",
                    IdCuentaProductoBancario            = data.account?.bank_product_id ?? "",
                    IdLink                              = data.account?.link            ?? "",
                    TransaccionContableFecha            = data.accounting_date,
                    TransaccionMonto                    = data.amount,
                    TransaccionSaldo                    = data.balance,
                    TransaccionCategoria                = data.category,
                    RecoleccionFecha                    = data.collected_at,
                    CreadoFecha                         = data.created_at,
                    TarjetaCreditoFacturaMonto          = data.credit_card_data?.bill_amount         ?? 0,
                    TarjetaCreditoFacturaNombre         = data.credit_card_data?.bill_name           ?? "",
                    TarjetaCreditoFacturaEstatusName    = data.credit_card_data?.bill_status         ?? "",
                    TarjetaCreditoRecoleccionFecha      = data.credit_card_data?.collected_at        ?? null,
                    TarjetaCreditoTotalFacturaAnterior  = Globals.ParseDecimalNull(data.credit_card_data?.previous_bill_total ?? "0.00"),
                    MonedaCodigo                        = data.currency,
                    TransaccionDescripcion              = data.description,
                    TransaccionIdentificacionInterna    = data.internal_identification,
                    ComercianteNombre                   = data.merchant?.merchant_name ?? "",
                    TransaccionObservaciones            = data.observations,
                    TransaccionReferencia               = data.reference,
                    TransaccionEstatusName              = data.status,
                    TransaccionSubCategoria             = data.subcategory,
                    TransaccionTipo                     = data.type,
                    TransaccionValorFecha               = data.value_date,
                };

                _context.Transacciones.Add(objModel);
                await _context.SaveChangesAsync();
                objTransaction.Commit();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw new ArgumentException("Error al crear el objeto Transacción: " + ex.Message, ex);
            }
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> DataSource(dynamic data)
        {
            // Obtener la lista de elementos a través de la expresión de origen de datos.
            IQueryable<TransaccionViewModel> lstItems                   = DataSourceExpression(data);
            // Construir el objeto de origen de datos usando el constructor adecuado.
            DataSourceBuilder<TransaccionViewModel> objDataTableBuilder = new DataSourceBuilder<TransaccionViewModel>(data, lstItems);

            // Obtener el resultado del objeto de origen de datos.
            var objDataTableResult                  = await objDataTableBuilder.build();
            List<TransaccionViewModel> lstOriginal  = objDataTableResult.rows;

            // Proyectar las propiedades deseadas en una nueva lista de objetos.
            var lstRows = lstOriginal.Select(x => new
            {
                IdTransaccion               = x.IdTransaccion,
                TransaccionContableFecha    = x.TransaccionContableFecha,
                TransaccionCategoria        = x.TransaccionCategoria,
            }).ToList();

            // Construir el objeto de devolución con la lista proyectada y otras propiedades.
            var objReturn = new
            {
                rows        = lstRows,
                count       = objDataTableResult.count,
                length      = objDataTableResult.length,
                pages       = objDataTableResult.pages,
                page        = objDataTableResult.page,
            };

            return objReturn;
        }

        public IQueryable<TransaccionViewModel> DataSourceExpression(dynamic data)
        {
            // INCLUDES
            IQueryable<TransaccionViewModel> lstItems;

            // APLICAR FILTROS DINÁMICOS
            // FILTROS
            var dictFilters = new Dictionary<string, Func<string, Expression<Func<Transaccion, bool>>>>
            {
                { "CreatedAspNetUser.Id", (strValue) => item => item.IdCreatedUser == strValue },
                { "UpdatedAspNetUser.Id", (strValue) => item => item.IdUpdatedUser == strValue },
            };

            // FILTROS MÚLTIPLES
            var dictMultipleFilters = new Dictionary<string, Func<string, Expression<Func<Transaccion, bool>>>> { };

            // FILTROS FECHAS
            DateTime? dateFrom  = SourceExpression<Transaccion>.Date((string)data.dateFrom);
            DateTime? dateTo    = SourceExpression<Transaccion>.Date((string)data.dateTo);

            var dictDates = new Dictionary<string, DateExpression<Transaccion>>()
            {
                { "CreatedFecha", new DateExpression<Transaccion>{ dateFrom = item => item.CreatedFecha.Date >= dateFrom, dateTo = item => item.CreatedFecha.Date <= dateTo } },
                { "UpdatedFecha", new DateExpression<Transaccion>{ dateFrom = item => item.UpdatedFecha.Date >= dateFrom, dateTo = item => item.UpdatedFecha.Date <= dateTo } },
            };

            Expression<Func<Transaccion, bool>> ExpFullWhere = SourceExpression<Transaccion>.GetExpression(data, dictFilters, dictDates, dictMultipleFilters);

            // ORDER BY
            var orderColumn     = Globals.ToString(data.sort.column);
            var orderDirection  = Globals.ToString(data.sort.direction);

            Expression<Func<Transaccion, object>> sortExpression;

            switch (orderColumn)
            {
                case "createdFecha"     : sortExpression = (x => x.CreatedFecha);   break;
                case "updatedFecha"     : sortExpression = (x => x.UpdatedFecha);   break;
                default                 : sortExpression = (x => x.CreatedFecha);   break;
            }

            List<string> columns = Globals.GetArrayColumns(data);

            columns.Add("IdTransaccion");
            columns.Add("CreatedFecha");
            columns.Add("TransaccionContableFecha");
            columns.Add("TransaccionCategoria");

            string strColumns = Globals.GetStringColumns(columns);

            IQueryable<Transaccion> rows = _context.Transacciones.AsNoTracking();

            if (orderDirection == "asc")
            {
                rows = rows.OrderBy(sortExpression);
            }
            else
            {
                rows = rows.OrderByDescending(sortExpression);
            }

            lstItems = rows
                        .Where(x => !x.Deleted)
                        .Where(ExpFullWhere)
                        .Select(Globals.BuildSelector<Transaccion,Transaccion>(strColumns))
                        .ProjectTo<TransaccionViewModel>(_mapper.ConfigurationProvider);

            return lstItems;
        }

        public async Task Delete(dynamic data, ClaimsPrincipal user)
        {
            using var objTransaction = _context.Database.BeginTransaction();
            try
            {
                string id = Globals.ParseGuid(data.idTransaccion);
                Transaccion objModel = await Find(id) ?? throw new ArgumentException($"No se encontró la transacción con el Id: {id}");

                if (objModel.Deleted) { throw new InvalidOperationException($"El objeto Transacción con el Id {id} ya ha sido marcado como eliminado."); }

                objModel.Deleted = true;
                objModel.SetUpdated(Globals.GetUser(user));

                _context.Transacciones.Update(objModel);
                await _context.SaveChangesAsync();
                objTransaction.Commit();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw new ArgumentException("Error al eliminar el objeto Transacción: " + ex.Message, ex);
            }
        }

        public async Task<Transaccion> Find(string id)
        {
            var transaccion = await _context.Transacciones.FindAsync(id);
            return transaccion ?? throw new ArgumentException($"No se encontró la transacción con el Id: {id}");
        }

        public async Task<Transaccion> FindSelectorById(string id, string fields)
        {
            var transaccion = await _context.Transacciones.Where(x => x.IdTransaccion == id).Select(Globals.BuildSelector<Transaccion, Transaccion>(fields)).FirstOrDefaultAsync();
            return transaccion ?? throw new ArgumentException($"No se encontró la transacción con el Id: {id} o el campo especificado '{fields}' no es válido en la búsqueda.");
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Transacciones.AsNoTracking().Where(x => !x.Deleted).Select(x => new { x.IdLink, x.TransaccionContableFecha, x.TransaccionReferencia }).ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListSelectorById(string id, string fields)
        {
            var transaccion = await _context.Transacciones.AsNoTracking().Where(x => !x.Deleted && x.IdTransaccion == id).Select(Globals.BuildSelector<Transaccion, Transaccion>(fields)).ToListAsync<dynamic>();
            return transaccion ?? throw new ArgumentException($"No se encontró la transacción con el Id: {id} o el campo especificado '{fields}' no es válido en la búsqueda.");
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            using var objTransaction = _context.Database.BeginTransaction();
            try
            {
                string id               = Globals.ParseGuid(data.idTransaccion);
                Transaccion objModel    = await Find(id) ?? throw new ArgumentException($"No se encontró la transacción con el Id: {id}");

                objModel.IdCuenta                           = data.account?.id ?? "";
                objModel.IdCuentaProductoBancario           = data.account?.bank_product_id ?? "";
                objModel.IdLink                             = data.account?.link ?? "";
                objModel.TransaccionContableFecha           = data.accounting_date;
                objModel.TransaccionMonto                   = data.amount;
                objModel.TransaccionSaldo                   = data.balance;
                objModel.TransaccionCategoria               = data.category;
                objModel.RecoleccionFecha                   = data.collected_at;
                objModel.CreadoFecha                        = data.created_at;
                objModel.TarjetaCreditoFacturaMonto         = data.credit_card_data?.bill_amount ?? 0;
                objModel.TarjetaCreditoFacturaNombre        = data.credit_card_data?.bill_name ?? "";
                objModel.TarjetaCreditoFacturaEstatusName   = data.credit_card_data?.bill_status ?? "";
                objModel.TarjetaCreditoRecoleccionFecha     = data.credit_card_data?.collected_at ?? null;
                objModel.TarjetaCreditoTotalFacturaAnterior = Globals.ParseDecimalNull(data.credit_card_data?.previous_bill_total ?? "0.00");
                objModel.MonedaCodigo                       = data.currency;
                objModel.TransaccionDescripcion             = data.description;
                objModel.TransaccionIdentificacionInterna   = data.internal_identification;
                objModel.ComercianteNombre                  = data.merchant?.merchant_name ?? "";
                objModel.TransaccionObservaciones           = data.observations;
                objModel.TransaccionReferencia              = data.reference;
                objModel.TransaccionEstatusName             = data.status;
                objModel.TransaccionSubCategoria            = data.subcategory;
                objModel.TransaccionTipo                    = data.type;
                objModel.TransaccionValorFecha              = data.value_date;

                _context.Transacciones.Update(objModel);
                await _context.SaveChangesAsync();
                objTransaction.Commit();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw new ArgumentException("Error al actualizar el objeto Transacción: " + ex.Message, ex);
            }
        }
    }
}