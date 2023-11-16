using API.Belvo.Models;
using API.Belvo.Persistence;
using API.Belvo.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
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

            Transaccion objModel                        = new Transaccion();            
            objModel.IdTransaccion                      = data.id;
            objModel.IdCuenta                           = data.account?.id              ?? "";
            objModel.IdCuentaProductoBancario           = data.account?.bank_product_id ?? "";
            objModel.IdLink                             = data.account?.link            ?? "";
            objModel.TransaccionContableFecha           = data.accounting_date;
            objModel.TransaccionMonto                   = data.amount;
            objModel.TransaccionSaldo                   = data.balance;
            objModel.TransaccionCategoria               = data.category;
            objModel.RecoleccionFecha                   = data.collected_at;
            objModel.CreadoFecha                        = data.created_at;
            objModel.TarjetaCreditoFacturaMonto         = data.credit_card_data?.bill_amount         ?? 0;
            objModel.TarjetaCreditoFacturaNombre        = data.credit_card_data?.bill_name           ?? "";
            objModel.TarjetaCreditoFacturaEstatusName   = data.credit_card_data?.bill_status         ?? "";
            objModel.TarjetaCreditoRecoleccionFecha     = data.credit_card_data?.collected_at        ?? null;
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
            
            _context.Transacciones.Add(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> DataSource(dynamic data)
        {
            IQueryable<TransaccionViewModel> lstItems                   = DataSourceExpression(data);
            DataSourceBuilder<TransaccionViewModel> objDataTableBuilder = new DataSourceBuilder<TransaccionViewModel>(data, lstItems);

            var objDataTableResult                  = await objDataTableBuilder.build();
            List<TransaccionViewModel> lstOriginal  = objDataTableResult.rows;
            List<dynamic> lstRows                   = new List<dynamic>();

            lstOriginal.ForEach(x =>
            {
                lstRows.Add(new
                {
                    IdTransaccion               = x.IdTransaccion,
                    TransaccionReferencia       = x.TransaccionReferencia,
                    TransaccionDescripcion      = x.TransaccionDescripcion,
                    TransaccionEstatusName      = x.TransaccionEstatusName,
                    CreadoFecha                 = x.CreadoFechaNatural,
                    RecoleccionFecha            = x.RecoleccionFechaNatural,
                    TransaccionCategoria        = x.TransaccionCategoria,
                    TransaccionSubCategoria     = x.TransaccionSubCategoria,
                    TransaccionTipo             = x.TransaccionTipo,
                    TransaccionObservaciones    = x.TransaccionObservaciones,
                    MonedaCodigo                = x.MonedaCodigo,
                    TransaccionMonto            = x.TransaccionMontoNatural,
                    TransaccionSaldo            = x.TransaccionSaldoNatural,
                    ComercianteNombre           = x.ComercianteNombre,
                    CreatedUserName             = x.CreatedUserName,
                    CreatedFecha                = x.CreatedFechaNatural,
                    UpdatedUserName             = x.UpdatedUserName,
                    UpdatedFecha                = x.UpdatedFechaNatural,
                });
            });

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
                { "IdCuenta",   (strValue) => item => item.IdCuenta         == strValue },
                { "IdUser",     (strValue) => item => item.IdCreatedUser    == strValue },
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

            string idUser   = Globals.ParseGuid(data.idUser);
            string idCuenta = Globals.ParseGuid(data.idCuenta);

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
                        .Select(Globals.BuildSelector<Transaccion, Transaccion>(strColumns))
                        .ProjectTo<TransaccionViewModel>(_mapper.ConfigurationProvider);

            return lstItems;
        }

        public async Task Delete(dynamic data, ClaimsPrincipal user)
        {
            using var objTransaction = _context.Database.BeginTransaction();

            string id = Globals.ParseGuid(data.idTransaccion);
            Transaccion objModel = await Find(id) ?? throw new ArgumentException(String.Format("No se encontró la transacción con el Id: {0}", id));

            if (objModel.Deleted) { throw new ArgumentException(String.Format("La transacción con el Id {0} ya había sido eliminada previamente.", id)); }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Transacciones.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<Transaccion> Find(string id)
        {
            return await _context.Transacciones.FindAsync(id) ?? throw new ArgumentException(String.Format("No se encontró la transacción con el Id: {0}", id));
        }

        public async Task<Transaccion> FindSelectorById(string id, string fields)
        {
            var transaccion = await _context.Transacciones.Where(x => x.IdTransaccion == id).Select(Globals.BuildSelector<Transaccion, Transaccion>(fields)).FirstOrDefaultAsync();
            return transaccion ?? throw new ArgumentException(String.Format("No se encontró la transacción con el Id: {0} o el campo especificado '{1}' no es válido en la búsqueda.", id, fields));
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Transacciones.AsNoTracking().Where(x => !x.Deleted).Select(x => new { x.IdLink, x.TransaccionContableFecha, x.TransaccionReferencia }).ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListSelectorById(string id, string fields)
        {
            var transaccion = await _context.Transacciones.Where(x => !x.Deleted && x.IdTransaccion == id).Select(Globals.BuildSelector<Transaccion, Transaccion>(fields)).ToListAsync<dynamic>();
            return transaccion ?? throw new ArgumentException(String.Format("No se encontró la transacción con el Id: {0} o el campo especificado '{1}' no es válido en la búsqueda.", id, fields));
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            using var objTransaction = _context.Database.BeginTransaction();

            string id               = Globals.ParseGuid(data.idTransaccion);
            Transaccion objModel    = await Find(id) ?? throw new ArgumentException(String.Format("No se encontró la transacción con el Id: {0}", id));

            objModel.IdCuenta                           = data.account?.id              ?? "";
            objModel.IdCuentaProductoBancario           = data.account?.bank_product_id ?? "";
            objModel.IdLink                             = data.account?.link            ?? "";
            objModel.TransaccionContableFecha           = data.accounting_date;
            objModel.TransaccionMonto                   = data.amount;
            objModel.TransaccionSaldo                   = data.balance;
            objModel.TransaccionCategoria               = data.category;
            objModel.RecoleccionFecha                   = data.collected_at;
            objModel.CreadoFecha                        = data.created_at;
            objModel.TarjetaCreditoFacturaMonto         = data.credit_card_data?.bill_amount    ?? 0;
            objModel.TarjetaCreditoFacturaNombre        = data.credit_card_data?.bill_name      ?? "";
            objModel.TarjetaCreditoFacturaEstatusName   = data.credit_card_data?.bill_status    ?? "";
            objModel.TarjetaCreditoRecoleccionFecha     = data.credit_card_data?.collected_at   ?? null;
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
    }
}