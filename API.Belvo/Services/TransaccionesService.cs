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
            var objTransaction = _context.Database.BeginTransaction();

            Transaccion objModel = new Transaccion();
            objModel.IdTransaccion                      = Guid.NewGuid().ToString();
            objModel.IdExterno                          = data.external_id;
            objModel.AccountingFecha                    = data.accounting_date;
            objModel.IdCuenta                           = data.account?.id ?? "";
            objModel.IdCuentaProductoBancario           = data.account?.bank_product_id ?? "";
            objModel.Monto                              = data.amount;
            objModel.Saldo                              = data.balance;
            objModel.Categoria                          = data.category;
            objModel.CollectedFecha                     = data.collected_at;
            objModel.TransaccionCreatedFecha            = data.created_at;
            objModel.MonedaCodigo                       = data.currency;
            objModel.Descripcion                        = data.description;
            objModel.IdentificacionInterna              = data.internal_identification;
            objModel.Observaciones                      = data.observations;
            objModel.Referencia                         = data.reference;
            objModel.TransaccionEstatusName             = data.status;
            objModel.SubCategoria                       = data.subcategory;
            objModel.Tipo                               = data.type;
            objModel.ValueFecha                         = data.value_date;
            objModel.ComercianteNombre                  = data.merchant.merchant_name;
            objModel.TarjetaCreditoCuentaNombre         = data.credit_card_data.bill_name;
            objModel.TarjetaCreditoTotalCuentaAnterior  = data.credit_card_data.previous_bill_total;
            objModel.TarjetaCreditoCollectedFecha       = data.credit_card_data.collected_at;

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
            IQueryable<TransaccionViewModel> lstItems = DataSourceExpression(data);
            DataSourceBuilder<TransaccionViewModel> objDataTableBuilder = new DataSourceBuilder<TransaccionViewModel>(data, lstItems);

            var objDataTableResult = await objDataTableBuilder.build();
            List<TransaccionViewModel> lstOriginal = objDataTableResult.rows;
            List<dynamic> lstRows = new List<dynamic>();

            lstOriginal.ForEach(x =>
            {
                lstRows.Add(new
                {
                    IdTransaccion   = x.IdTransaccion,
                    AccountingFecha = x.AccountingFecha,
                    Categoria       = x.Categoria,
                });
            });

            var objReturn = new
            {
                rows    = lstRows,
                count   = objDataTableResult.count,
                length  = objDataTableResult.length,
                pages   = objDataTableResult.pages,
                page    = objDataTableResult.page,
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
            DateTime? dateFrom = SourceExpression<Transaccion>.Date((string)data.dateFrom);
            DateTime? dateTo = SourceExpression<Transaccion>.Date((string)data.dateTo);

            var dictDates = new Dictionary<string, DateExpression<Transaccion>>()
            {
                { "CreatedFecha", new DateExpression<Transaccion> { dateFrom = item => item.CreatedFecha.Date >= dateFrom, dateTo = item => item.CreatedFecha.Date <= dateTo } },
                { "UpdatedFecha", new DateExpression<Transaccion> { dateFrom = item => item.UpdatedFecha.Date >= dateFrom, dateTo = item => item.UpdatedFecha.Date <= dateTo } },
            };

            Expression<Func<Transaccion, bool>> ExpFullWhere = SourceExpression<Transaccion>.GetExpression(data, dictFilters, dictDates, dictMultipleFilters);

            // ORDER BY
            var orderColumn = Globals.ToString(data.sort.column);
            var orderDirection = Globals.ToString(data.sort.direction);

            Expression<Func<Transaccion, object>> sortExpression;
            switch (orderColumn)
            {
                case "createdFecha"     : sortExpression = (x => x.CreatedFecha);       break;
                case "updatedFecha"     : sortExpression = (x => x.UpdatedFecha);       break;
                default                 : sortExpression = (x => x.CreatedFecha);       break;
            }

            List<string> columns = Globals.GetArrayColumns(data);

            columns.Add("IdTransaccion");
            columns.Add("CreatedFecha");
            columns.Add("AccountingFecha");
            columns.Add("Categoria");

            string strColumns = Globals.GetStringColumns(data);

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
                        .Select(Globals.BuildSelector<Transaccion, Transaccion>(strColumns))
                        .ProjectTo<TransaccionViewModel>(_mapper.ConfigurationProvider);

            return lstItems;
        }

        public async Task Delete(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();
            string idTransaccion = Globals.ParseGuid(data.idTransaccion);
            Transaccion objModel = await Find(idTransaccion);

            if (objModel == null) { throw new ArgumentException("No se ha podido encontrar la transacción especificada."); }
            if (objModel.Deleted) { throw new ArgumentException("Esta transacción ya había sido eliminado anteriormente."); }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Transacciones.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<Transaccion> Find(string id)
        {
            var transaccion = await _context.Transacciones.FindAsync(id);
            return transaccion ?? throw new ArgumentException("No se encontró la transacción con el ID " + id);
        }

        public async Task<Transaccion> FindSelectorById(string id, string fields)
        {
            var transaccion = await _context.Transacciones.Where(x => x.IdTransaccion == id).Select(Globals.BuildSelector<Transaccion, Transaccion>(fields)).FirstOrDefaultAsync();
            return transaccion ?? throw new ArgumentException("No se encontró la transacción con el ID " + id);
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Transacciones.AsNoTracking().Where(x => !x.Deleted).Select(x => new { x.IdTransaccion, x.AccountingFecha, x.Referencia }).ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListSelectorById(string id, string fields)
        {
            return await _context.Transacciones.AsNoTracking().Where(x => !x.Deleted && x.IdTransaccion == id).Select(Globals.BuildSelector<Transaccion, Transaccion>(fields)).ToListAsync<dynamic>();
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();
            string idTransaccion = Globals.ParseGuid(data.idTransaccion);
            Transaccion objModel = await Find(idTransaccion);

            if (objModel == null) { throw new ArgumentException("No se ha podido encontrar la transacción especificada."); }

            objModel.IdExterno                          = data.external_id;
            objModel.AccountingFecha                    = data.accounting_date;
            objModel.IdCuenta                           = data.account?.id ?? "";
            objModel.IdCuentaProductoBancario           = data.account?.bank_product_id ?? "";
            objModel.Monto                              = data.amount;
            objModel.Saldo                              = data.balance;
            objModel.Categoria                          = data.category;
            objModel.CollectedFecha                     = data.collected_at;
            objModel.TransaccionCreatedFecha            = data.created_at;
            objModel.MonedaCodigo                       = data.currency;
            objModel.Descripcion                        = data.description;
            objModel.IdentificacionInterna              = data.internal_identification;
            objModel.Observaciones                      = data.observations;
            objModel.Referencia                         = data.reference;
            objModel.TransaccionEstatusName             = data.status;
            objModel.SubCategoria                       = data.subcategory;
            objModel.Tipo                               = data.type;
            objModel.ValueFecha                         = data.value_date;
            objModel.ComercianteNombre                  = data.merchant.merchant_name;
            objModel.TarjetaCreditoCuentaNombre         = data.credit_card_data.bill_name;
            objModel.TarjetaCreditoTotalCuentaAnterior  = data.credit_card_data.previous_bill_total;
            objModel.TarjetaCreditoCollectedFecha       = data.credit_card_data.collected_at;

            _context.Transacciones.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
