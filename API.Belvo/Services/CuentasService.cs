using System.Linq.Expressions;
using System.Security.Claims;
using API.Belvo.Models;
using API.Belvo.Persistence;
using API.Belvo.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using iTextSharp.text.html.simpleparser;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Workcube.Interfaces;
using Workcube.Libraries;
using Workcube.ViewModels;

namespace API.Belvo.Services
{
    public class CuentasService : IGlobal<Cuenta>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public CuentasService(Context context, IMapper mapper) 
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
                Cuenta objModel = new Cuenta
                {
                    IdCuenta                            = Guid.NewGuid().ToString(),
                    CuentaAgencia                       = data.agency,
                    SaldoDisponible                     = data.balance_available,
                    SaldoActual                         = data.balance_current,
                    CuentaTipoSaldo                     = data.balance_type,
                    IdProductoBancario                  = data.bank_product_id,
                    CuentaCategoria                     = data.category,
                    RecoleccionFecha                    = data.collected_at,
                    CreadoFecha                         = data.created_at,
                    CreditoRecoleccionFecha             = data.credit_data?.collected_at        ?? null,
                    CreditoLimite                       = data.credit_data?.credit_limit        ?? 0,
                    CreditoCorteFecha                   = data.credit_data?.cutting_date        ?? "",
                    CreditoTasaInteres                  = data.credit_data?.interest_rate       ?? 0,
                    CreditoSaldoUltimoPeriodo           = data.credit_data?.last_period_balance ?? 0,
                    CreditoUltimoPagoFecha              = data.credit_data?.last_payment_date   ?? "",
                    CreditoPagoMinimo                   = data.credit_data?.minimum_payment     ?? 0,
                    CreditoPagoMensual                  = data.credit_data?.monthly_payment     ?? 0,
                    CreditoProximoPagoFecha             = data.credit_data?.next_payment_date   ?? "",
                    CreditoPagoSinInteres               = data.credit_data?.no_interest_payment ?? 0,
                    MonedaCodigo                        = data.currency,
                    FondosSaldo                         = data.funds_data?.balance      ?? 0,
                    FondosRecoleccionFecha              = data.funds_data?.collected_at ?? null,
                    FondosNombre                        = data.funds_data?.name         ?? "",
                    FondosPorcentaje                    = data.funds_data?.percentage   ?? 0,
                    FondosIdentificacionPublicaJson     = JsonConvert.SerializeObject(data.funds_data?.public_identifications ?? new List<IdentificacionPublica>()),
                    FondosTipo                          = data.funds_data?.type ?? "",
                    IdCuentaBelvo                       = data.id,
                    InstitucionNombre                   = data.institution_name,
                    InstitucionTipo                     = data.institution_type,
                    InstitucionCodigo                   = data.institution_code,
                    CuentaIdentificacionInterna         = data.internal_identification,
                    UltimoAccesoFecha                   = data.last_accessed_at ?? null,
                    IdLink                              = data.link,
                    PrestamoRecoleccionFecha            = data.loan_data?.collected_at          ?? null,
                    PrestamoMontoContrato               = data.loan_data?.contract_amount       ?? 0,
                    PrestamoContratoFinalizacionFecha   = data.loan_data?.contract_end_date     ?? "",
                    PrestamoNumeroContrato              = data.loan_data?.contract_number       ?? "",
                    PrestamoContratoInicioFecha         = data.loan_data?.contract_start_date   ?? "",
                    PrestamoCorteFecha                  = data.loan_data?.cutting_date          ?? "",
                    PrestamoDiaCorte                    = data.loan_data?.cutting_day           ?? "",
                    PrestamoTarifaJson                  = JsonConvert.SerializeObject(data.loan_data?.fees ?? new List<Tarifa>()),
                    PrestamoTasaInteresJson             = JsonConvert.SerializeObject(data.loan_data?.interest_rates ?? new List<TasaInteres>()),
                    PrestamoUltimoPagoFecha             = data.loan_data?.last_payment_date     ?? "",
                    PrestamoTipo                        = data.loan_data?.loan_type             ?? "",
                    PrestamoPagoMensual                 = data.loan_data?.monthly_payment       ?? 0,
                    PrestamoPagoSinInteres              = data.loan_data?.no_interest_payment   ?? 0,
                    PrestamoNumeroCuotasTotal           = Globals.ParseIntNull(data.loan_data?.number_of_installments_total ?? "0"),
                    PrestamoNumeroCuotasPendientes      = Globals.ParseIntNull(data.loan_data?.number_of_installments_outstanding ?? "0"),
                    PrestamoSaldoPendientePago          = data.loan_data?.outstanding_balance   ?? 0,
                    PrestamoPrincipalPendientePago      = data.loan_data?.outstanding_principal ?? 0,
                    PrestamoDiaPago                     = data.loan_data?.payment_day           ?? "",
                    PrestamoPrincipal                   = data.loan_data?.principal             ?? 0,
                    CuentaNombre                        = data.name,
                    CuentaNumero                        = data.number,
                    CuentaIdentificacionPublicaNombre   = data.public_identification_name,
                    CuentaIdentificacionPublicaValor    = data.public_identification_value,
                    CuentasPorCobrarAnticipado          = data.receivables_data?.anticipated    ?? 0,
                    CuentasPorCobrarDisponible          = data.receivables_data?.available      ?? 0,
                    CuentasPorCobrarRecoleccionFecha    = data.receivables_data?.collected_at   ?? null,
                    CuentasPorCobrarActual              = data.receivables_data?.current        ?? 0,
                    CuentaTipo                          = data.type,
                };

                _context.Cuentas.Add(objModel);
                await _context.SaveChangesAsync();
                objTransaction.Commit();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw new ArgumentException("Error al crear el objeto Cuenta: " + ex.Message, ex);
            }
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> DataSource(dynamic data)
        {
            // Obtener la lista de elementos a través de la expresión de origen de datos.
            IQueryable<CuentaViewModel> lstItems                    = DataSourceExpression(data);
            // Construir el objeto de origen de datos usando el constructor adecuado.
            DataSourceBuilder<CuentaViewModel> objDataTableBuilder  = new DataSourceBuilder<CuentaViewModel>(data, lstItems);

            // Obtener el resultado del objeto de origen de datos.
            var objDataTableResult              = await objDataTableBuilder.build();
            List<CuentaViewModel> lstOriginal   = objDataTableResult.rows;

            // Proyectar las propiedades deseadas en una nueva lista de objetos.
            var lstRows = lstOriginal.Select(x => new
            {
                IdCuenta    = x.IdCuenta,
                IdLink      = x.IdLink,
            }).ToList();

            // Construir el objeto de devolución con la lista proyectada y otras propiedades.
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

        public IQueryable<CuentaViewModel> DataSourceExpression(dynamic data)
        {
            // INCLUDES
            IQueryable<CuentaViewModel> lstItems;

            // APLICAR FILTROS DINÁMICOS
            // FILTROS
            var dictFilters = new Dictionary<string, Func<string, Expression<Func<Cuenta, bool>>>>
            {
                { "CreatedAspNetUser.Id", (strValue) => item => item.IdCreatedUser == strValue },
                { "UpdatedAspNetUser.Id", (strValue) => item => item.IdUpdatedUser == strValue },
            };

            // FILTROS MÚLTIPLES
            var dictMultipleFilters = new Dictionary<string, Func<string, Expression<Func<Cuenta, bool>>>> { };

            // FILTROS FECHAS
            DateTime? dateFrom  = SourceExpression<Cuenta>.Date((string)data.dateFrom);
            DateTime? dateTo    = SourceExpression<Cuenta>.Date((string)data.dateTo);

            var dictDates = new Dictionary<string, DateExpression<Cuenta>>()
            {
                { "CreatedFecha", new DateExpression<Cuenta>{ dateFrom = item => item.CreatedFecha.Date >= dateFrom, dateTo = item => item.CreatedFecha.Date <= dateTo } },
                { "UpdatedFecha", new DateExpression<Cuenta>{ dateFrom = item => item.UpdatedFecha.Date >= dateFrom, dateTo = item => item.UpdatedFecha.Date <= dateTo } },
            };

            Expression<Func<Cuenta, bool>> ExpFullWhere = SourceExpression<Cuenta>.GetExpression(data, dictFilters, dictDates, dictMultipleFilters);

            // ORDER BY
            var orderColumn     = Globals.ToString(data.sort.column);
            var orderDirection  = Globals.ToString(data.sort.direction);

            Expression<Func<Cuenta, object>> sortExpression;

            switch (orderColumn)
            {
                case "createdUserName"  : sortExpression = (x => x.CreatedUserName);    break;
                case "createdFecha"     : sortExpression = (x => x.CreatedFecha);       break;
                case "updatedUserName"  : sortExpression = (x => x.UpdatedUserName);    break;
                case "updatedFecha"     : sortExpression = (x => x.UpdatedFecha);       break;
                default                 : sortExpression = (x => x.CreatedFecha);       break;
            }

            List<string> columns = Globals.GetArrayColumns(data);

            columns.Add("IdCuenta");
            columns.Add("IdCreatedUser");
            columns.Add("CreatedUserName");
            columns.Add("IdUpdatedUser");
            columns.Add("UpdatedUserName");

            string strColumns = Globals.GetStringColumns(columns);

            IQueryable<Cuenta> rows = _context.Cuentas.AsNoTracking();

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
                        .Select(Globals.BuildSelector<Cuenta, Cuenta>(strColumns))
                        .ProjectTo<CuentaViewModel>(_mapper.ConfigurationProvider);

            return lstItems;
        }

        public async Task Delete(dynamic data, ClaimsPrincipal user)
        {
            using var objTransaction = _context.Database.BeginTransaction();
            try
            {
                string id = Globals.ParseGuid(data.idCuenta);
                Cuenta objModel = await Find(id) ?? throw new ArgumentException($"No se encontró la cuenta con el Id: {id}");

                if (objModel.Deleted) { throw new InvalidOperationException($"El objeto Cuenta con el Id {id} ya ha sido marcado como eliminado."); }

                objModel.Deleted = true;
                objModel.SetUpdated(Globals.GetUser(user));

                _context.Cuentas.Update(objModel);
                await _context.SaveChangesAsync();
                objTransaction.Commit();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw new ArgumentException("Error al eliminar el objeto Cuenta: " + ex.Message, ex);
            }
        }

        public async Task<Cuenta> Find(string id)
        {
            var cuenta = await _context.Cuentas.FindAsync(id);
            return cuenta ?? throw new ArgumentException($"No se encontró la transacción con el Id: {id}");
        }

        public async Task<Cuenta> FindSelectorById(string id, string fields)
        {
            var cuenta = await _context.Cuentas.Where(x => x.IdCuenta == id).Select(Globals.BuildSelector<Cuenta, Cuenta>(fields)).FirstOrDefaultAsync();
            return cuenta ?? throw new ArgumentException($"No se encontró la cuenta con el Id: {id} o el campo especificado '{fields}' no es válido en la búsqueda.");
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Cuentas.AsNoTracking().Where(x => !x.Deleted).Select(x => new { x.IdCuenta, x.IdLink, x.CuentaNombre }).ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListSelectorById(string id, string fields)
        {
            var cuenta = await _context.Cuentas.AsNoTracking().Where(x => !x.Deleted && x.IdCuenta == id).Select(Globals.BuildSelector<Cuenta, Cuenta>(fields)).ToListAsync<dynamic>();
            return cuenta ?? throw new ArgumentException($"No se encontró la cuenta con el Id: {id} o el campo especificado '{fields}' no es válido en la búsqueda.");
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
                string id           = Globals.ParseGuid(data.idCuenta);
                Cuenta objModel     = await Find(id) ?? throw new ArgumentException($"No se encontró la cuenta con el Id: {id}");

                objModel.CuentaAgencia                      = data.agency;
                objModel.SaldoDisponible                    = data.balance_available;
                objModel.SaldoActual                        = data.balance_current;
                objModel.CuentaTipoSaldo                    = data.balance_type;
                objModel.IdProductoBancario                 = data.bank_product_id;
                objModel.CuentaCategoria                    = data.category;
                objModel.RecoleccionFecha                   = data.collected_at;
                objModel.CreadoFecha                        = data.created_at;
                objModel.CreditoRecoleccionFecha            = data.credit_data?.collected_at        ?? null;
                objModel.CreditoLimite                      = data.credit_data?.credit_limit        ?? 0;
                objModel.CreditoCorteFecha                  = data.credit_data?.cutting_date        ?? "";
                objModel.CreditoTasaInteres                 = data.credit_data?.interest_rate       ?? 0;
                objModel.CreditoSaldoUltimoPeriodo          = data.credit_data?.last_period_balance ?? 0;
                objModel.CreditoUltimoPagoFecha             = data.credit_data?.last_payment_date   ?? "";
                objModel.CreditoPagoMinimo                  = data.credit_data?.minimum_payment     ?? 0;
                objModel.CreditoPagoMensual                 = data.credit_data?.monthly_payment     ?? 0;
                objModel.CreditoProximoPagoFecha            = data.credit_data?.next_payment_date   ?? "";
                objModel.CreditoPagoSinInteres              = data.credit_data?.no_interest_payment ?? 0;
                objModel.MonedaCodigo                       = data.currency;
                objModel.FondosSaldo                        = data.funds_data?.balance      ?? 0;
                objModel.FondosRecoleccionFecha             = data.funds_data?.collected_at ?? null;
                objModel.FondosNombre                       = data.funds_data?.name         ?? "";
                objModel.FondosPorcentaje                   = data.funds_data?.percentage   ?? 0;
                objModel.FondosIdentificacionPublicaJson    = JsonConvert.SerializeObject(data.funds_data?.public_identifications ?? new List<IdentificacionPublica>());
                objModel.FondosTipo                         = data.funds_data?.type ?? "";
                objModel.IdCuentaBelvo                      = data.id;
                objModel.InstitucionNombre                  = data.institution_name;
                objModel.InstitucionTipo                    = data.institution_type;
                objModel.InstitucionCodigo                  = data.institution_code;
                objModel.CuentaIdentificacionInterna        = data.internal_identification;
                objModel.UltimoAccesoFecha                  = data.last_accessed_at ?? null;
                objModel.IdLink                             = data.link;
                objModel.PrestamoRecoleccionFecha           = data.loan_data?.collected_at          ?? null;
                objModel.PrestamoMontoContrato              = data.loan_data?.contract_amount       ?? 0;
                objModel.PrestamoContratoFinalizacionFecha  = data.loan_data?.contract_end_date     ?? "";
                objModel.PrestamoNumeroContrato             = data.loan_data?.contract_number       ?? "";
                objModel.PrestamoContratoInicioFecha        = data.loan_data?.contract_start_date   ?? "";
                objModel.PrestamoCorteFecha                 = data.loan_data?.cutting_date          ?? "";
                objModel.PrestamoDiaCorte                   = data.loan_data?.cutting_day           ?? "";
                objModel.PrestamoTarifaJson                 = JsonConvert.SerializeObject(data.loan_data?.fees ?? new List<Tarifa>());
                objModel.PrestamoTasaInteresJson            = JsonConvert.SerializeObject(data.loan_data?.interest_rates ?? new List<TasaInteres>());
                objModel.PrestamoUltimoPagoFecha            = data.loan_data?.last_payment_date     ?? "";
                objModel.PrestamoTipo                       = data.loan_data?.loan_type             ?? "";
                objModel.PrestamoPagoMensual                = data.loan_data?.monthly_payment       ?? 0;
                objModel.PrestamoPagoSinInteres             = data.loan_data?.no_interest_payment   ?? 0;
                objModel.PrestamoNumeroCuotasTotal          = Globals.ParseIntNull(data.loan_data?.number_of_installments_total ?? "0");
                objModel.PrestamoNumeroCuotasPendientes     = Globals.ParseIntNull(data.loan_data?.number_of_installments_outstanding ?? "0");
                objModel.PrestamoSaldoPendientePago         = data.loan_data?.outstanding_balance   ?? 0;
                objModel.PrestamoPrincipalPendientePago     = data.loan_data?.outstanding_principal ?? 0;
                objModel.PrestamoDiaPago                    = data.loan_data?.payment_day           ?? "";
                objModel.PrestamoPrincipal                  = data.loan_data?.principal             ?? 0;
                objModel.CuentaNombre                       = data.name;
                objModel.CuentaNumero                       = data.number;
                objModel.CuentaIdentificacionPublicaNombre  = data.public_identification_name;
                objModel.CuentaIdentificacionPublicaValor   = data.public_identification_value;
                objModel.CuentasPorCobrarAnticipado         = data.receivables_data?.anticipated    ?? 0;
                objModel.CuentasPorCobrarDisponible         = data.receivables_data?.available      ?? 0;
                objModel.CuentasPorCobrarRecoleccionFecha   = data.receivables_data?.collected_at   ?? null;
                objModel.CuentasPorCobrarActual             = data.receivables_data?.current        ?? 0;
                objModel.CuentaTipo                         = data.type;
                objModel.SetUpdated(Globals.GetUser(user));

                _context.Cuentas.Update(objModel);
                await _context.SaveChangesAsync();
                objTransaction.Commit();
            }
            catch (Exception ex)
            {
                objTransaction.Rollback();
                throw new ArgumentException("Error al actualizar el objeto Cuenta: " + ex.Message, ex);
            }
        }
    }
}