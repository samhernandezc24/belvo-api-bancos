using System.Linq.Expressions;
using System.Security.Claims;
using API.Belvo.Models;
using API.Belvo.Persistence;
using API.Belvo.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly LinksService _linksService;

        public CuentasService(Context context, IMapper mapper, LinksService linksService) 
        {
            _context = context; 
            _mapper = mapper;
            _linksService = linksService;
        }

        public Task Create(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task Create(dynamic data)
        {
            var parameters = new
            {
                link = Globals.ParseGuid(data.idLink),
                token = "wfjkbwefjwefewfwef",
                isSave = true,
            };

            var result = await BelvoService.AccountsRetrieveByLink(parameters);

            if (!result.isSuccessful) { throw new ArgumentException(result.statusCode + " - No se pudo guardar la cuenta"); }

            CuentaListResult accountData = JsonConvert.DeserializeObject<CuentaListResult>(result.content);

            var objTransaction = _context.Database.BeginTransaction();

            Cuenta objModel = new Cuenta();
            objModel.IdCuenta                           = Guid.NewGuid().ToString();
            objModel.CuentaAgencia                      = data.agency;
            objModel.SaldoActual                        = data.balance?.current ?? 0;
            objModel.SaldoDisponible                    = data.balance?.available ?? 0;
            objModel.CuentaSaldoTipo                    = data.balance_type;
            objModel.IdProductoBancario                 = data.bank_product_id;
            objModel.CuentaCategoria                    = data.category;
            objModel.CuentaCollectedFecha               = data.collected_at;
            objModel.CuentaCreatedFecha                 = data.created_at;
            objModel.CreditoCollectedFecha              = data.credit_data?.collected_at ?? null;
            objModel.CreditoLimite                      = data.credit_data?.credit_limit ?? 0;            
            objModel.CreditoCuttingFecha                = data.credit_data.cutting_date;
            objModel.CreditoTasaInteres                 = data.credit_data?.interest_rate ?? 0;
            objModel.CreditoLastPaymentFecha            = data.credit_data?.last_payment_date ?? "";
            objModel.CreditoUltimoPeriodoSaldo          = data.credit_data?.last_period_balance ?? 0;
            objModel.CreditoPagoMinimo                  = data.credit_data?.minimum_payment ?? 0;
            objModel.CreditoPagoMensual                 = data.credit_data?.monthly_payment ?? 0;
            objModel.CreditoNextPaymentFecha            = data.credit_data?.next_payment_date ?? "";            
            objModel.CreditoSinPagoIntereses            = data.credit_data?.no_interest_payment ?? 0;
            objModel.CuentaMonedaCodigo                 = data.currency;
            objModel.IdExterno                          = data.external_id;
            objModel.FondosSaldo                        = data.funds_data?.balance ?? 0;
            objModel.FondosCollectedFecha               = data.funds_data?.collected_at ?? null;
            objModel.FondosNombre                       = data.funds_data?.name ?? "";            
            objModel.FondosPorcentaje                   = data.funds_data?.percentage ?? 0;
            objModel.FondosIdentificacionPublicaJson    = JsonConvert.SerializeObject(data.funds_data.public_identifications);
            objModel.FondosTipo                         = data.funds_data?.type ?? "";
            objModel.InstitucionNombre                  = data.institution?.name ?? "";
            objModel.InstitucionTipo                    = data.institution?.type ?? "";
            objModel.InstitucionCodigo                  = data.institution_code;
            objModel.CuentaIdentificacionInterna        = data.internal_identification;
            objModel.CuentaLastAccessedFecha            = data.last_accessed_at ?? null;
            objModel.IdLink                             = data.link;
            objModel.PrestamoCollectedFecha             = data.loan_data?.collected_at ?? null;
            objModel.PrestamoImporteContrato            = data.loan_data?.contract_amount ?? 0;
            objModel.PrestamoContractEndFecha           = data.loan_data?.contract_end_date ?? "";
            objModel.PrestamoNumeroContrato             = data.loan_data?.contract_number ?? "";
            objModel.PrestamoContractStartFecha         = data.loan_data?.contract_start_date ?? "";
            objModel.PrestamoCuttingFecha               = data.loan_data?.cutting_date ?? "";
            objModel.PrestamoDiaCorte                   = data.loan_data?.cutting_day ?? "";
            objModel.PrestamoTarifaJson                 = JsonConvert.SerializeObject(data.loan_data?.fees ?? new List<Tarifa>());
            objModel.PrestamoTasaInteresJson            = JsonConvert.SerializeObject(data.loan_data?.interest_rates ?? new List<TasaInteres>());
            objModel.PrestamoLastPaymentFecha           = data.loan_data?.last_payment_date ?? "";
            objModel.PrestamoTipo                       = data.loan_data?.loan_type ?? "";
            objModel.PrestamoPagoMensual                = data.loan_data?.monthly_payment ?? 0;
            objModel.PrestamoSinPagoIntereses           = data.loan_data?.no_interest_payment ?? 0;
            objModel.PrestamoNumeroPlazosTotal          = Globals.ParseIntNull(data.loan_data?.number_of_installments_total ?? "0");
            objModel.PrestamoNumeroPlazosPendientes     = Globals.ParseIntNull(data.loan_data?.number_of_installments_outstanding ?? "0");
            objModel.PrestamoSaldoPendientePago         = data.loan_data?.outstanding_balance ?? 0;
            objModel.PrestamoPrincipalPendientePago     = data.loan_data?.outstanding_principal ?? 0;
            objModel.PrestamoDiaPago                    = data.loan_data?.payment_day ?? "";
            objModel.PrestamoPrincipal                  = data.loan_data?.principal ?? 0;
            objModel.CuentaNombre                       = data.name;
            objModel.CuentaNumero                       = data.number;
            objModel.CuentaIdentificacionPublicaNombre  = data.public_identification_name;
            objModel.CuentaIdentificacionPublicaValor   = data.public_identification_value;
            objModel.CuentasPorCobrarValorAnticipado    = data.receivables_data?.anticipated ?? 0;
            objModel.CuentasPorCobrarValorDisponible    = data.receivables_data?.available ?? 0;
            objModel.CuentasPorCobrarCollectedFecha     = data.receivables_data?.collected_at ?? null;
            objModel.CuentasPorCobrarValorActual        = data.receivables_data?.current ?? 0;          
            objModel.CuentaTipo                         = data.type;
                       
            _context.Cuentas.Add(objModel);

            var objLink = await BelvoService.LinksDetails(objModel.IdLink);

            await _linksService.Create(objLink);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();            
        }

        public async Task<dynamic> DataSource(dynamic data)
        {
            IQueryable<CuentaViewModel> lstItems                    = DataSourceExpression(data);
            DataSourceBuilder<CuentaViewModel> objDataTableBuilder  = new DataSourceBuilder<CuentaViewModel>(data, lstItems);

            var objDataTableResult = await objDataTableBuilder.build();
            List<CuentaViewModel> lstOriginal = objDataTableResult.rows;
            List<dynamic> lstRows = new List<dynamic>();

            lstOriginal.ForEach(x =>
            {
                lstRows.Add(new
                {
                    IdCuenta    = x.IdCuenta,
                    IdLink      = x.IdLink,
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
            DateTime? dateFrom = SourceExpression<Cuenta>.Date((string)data.dateFrom);
            DateTime? dateTo = SourceExpression<Cuenta>.Date((string)data.dateTo);

            var dictDates = new Dictionary<string, DateExpression<Cuenta>>()
            {
                { "CreatedFecha", new DateExpression<Cuenta> { dateFrom = item => item.CreatedFecha.Date >= dateFrom, dateTo = item => item.CreatedFecha.Date <= dateTo } },
                { "UpdatedFecha", new DateExpression<Cuenta> { dateFrom = item => item.UpdatedFecha.Date >= dateFrom, dateTo = item => item.UpdatedFecha.Date <= dateTo } },
            };

            Expression<Func<Cuenta, bool>> ExpFullWhere = SourceExpression<Cuenta>.GetExpression(data, dictFilters, dictDates, dictMultipleFilters);

            // ORDER BY
            var orderColumn = Globals.ToString(data.sort.column);
            var orderDirection = Globals.ToString(data.sort.direction);

            Expression<Func<Cuenta, object>> sortExpression;
            switch (orderColumn)
            {
                case "createdUserName"      : sortExpression = (x => x.CreatedUserName);    break;
                case "createdFecha"         : sortExpression = (x => x.CreatedFecha);       break;
                case "updatedUserName"      : sortExpression = (x => x.UpdatedUserName);    break;
                case "updatedFecha"         : sortExpression = (x => x.UpdatedFecha);       break;
                default                     : sortExpression = (x => x.CreatedFecha);       break;
            }

            List<string> columns = Globals.GetArrayColumns(data);

            columns.Add("IdCuenta");
            columns.Add("IdCreatedUser");
            columns.Add("CreatedUserName");
            columns.Add("IdUpdatedUser");
            columns.Add("UpdatedUserName");

            string strColumns = Globals.GetStringColumns(data);

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
            var objTransaction = _context.Database.BeginTransaction();
            string idCuenta = Globals.ParseGuid(data.idCuenta);
            Cuenta objModel = await Find(idCuenta) ?? throw new ArgumentException("No se ha podido encontrar la cuenta especificada.");

            if (objModel.Deleted) { throw new ArgumentException("Esta cuenta ya había sido eliminada anteriormente."); }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Cuentas.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<Cuenta> Find(string id)
        {
            var cuenta = await _context.Cuentas.FindAsync(id);
            return cuenta ?? throw new ArgumentException("No se encontró la cuenta con el ID " + id);
        }

        public async Task<Cuenta> FindSelectorById(string id, string fields)
        {
            var cuenta = await _context.Cuentas.Where(x => x.IdCuenta == id).Select(Globals.BuildSelector<Cuenta, Cuenta>(fields)).FirstOrDefaultAsync();
            return cuenta ?? throw new ArgumentException("No se encontró una cuenta con el ID " + id);
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Cuentas.AsNoTracking().Where(x => !x.Deleted).Select(x => new { x.IdCuenta, x.IdLink, x.CuentaNombre }).ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListSelectorById(string id, string fields)
        {
            return await _context.Cuentas.AsNoTracking().Where(x => !x.Deleted && x.IdCuenta == id).Select(Globals.BuildSelector<Cuenta, Cuenta>(fields)).ToListAsync<dynamic>();
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();
            string idCuenta = Globals.ParseGuid(data.idCuenta);
            Cuenta objModel = await Find(idCuenta) ?? throw new ArgumentException("No se ha podido encontrar la cuenta especificada.");

            objModel.CuentaAgencia                      = data.agency;
            objModel.SaldoActual                        = data.balance?.current ?? 0;
            objModel.SaldoDisponible                    = data.balance?.available ?? 0;
            objModel.CuentaSaldoTipo                    = data.balance_type;
            objModel.IdProductoBancario                 = data.bank_product_id;
            objModel.CuentaCategoria                    = data.category;
            objModel.CuentaCollectedFecha               = data.collected_at;
            objModel.CuentaCreatedFecha                 = data.created_at;
            objModel.CreditoCollectedFecha              = data.credit_data?.collected_at ?? null;
            objModel.CreditoLimite                      = data.credit_data?.credit_limit ?? 0;
            objModel.CreditoCuttingFecha                = data.credit_data.cutting_date;
            objModel.CreditoTasaInteres                 = data.credit_data?.interest_rate ?? 0;
            objModel.CreditoLastPaymentFecha            = data.credit_data?.last_payment_date ?? "";
            objModel.CreditoUltimoPeriodoSaldo          = data.credit_data?.last_period_balance ?? 0;
            objModel.CreditoPagoMinimo                  = data.credit_data?.minimum_payment ?? 0;
            objModel.CreditoPagoMensual                 = data.credit_data?.monthly_payment ?? 0;
            objModel.CreditoNextPaymentFecha            = data.credit_data?.next_payment_date ?? "";
            objModel.CreditoSinPagoIntereses            = data.credit_data?.no_interest_payment ?? 0;
            objModel.CuentaMonedaCodigo                 = data.currency;
            objModel.IdExterno                          = data.external_id;
            objModel.FondosSaldo                        = data.funds_data?.balance ?? 0;
            objModel.FondosCollectedFecha               = data.funds_data?.collected_at ?? null;
            objModel.FondosNombre                       = data.funds_data?.name ?? "";
            objModel.FondosPorcentaje                   = data.funds_data?.percentage ?? 0;
            objModel.FondosIdentificacionPublicaJson    = JsonConvert.SerializeObject(data.funds_data.public_identifications);
            objModel.FondosTipo                         = data.funds_data?.type ?? "";
            objModel.InstitucionNombre                  = data.institution?.name ?? "";
            objModel.InstitucionTipo                    = data.institution?.type ?? "";
            objModel.InstitucionCodigo                  = data.institution_code;
            objModel.CuentaIdentificacionInterna        = data.internal_identification;
            objModel.CuentaLastAccessedFecha            = data.last_accessed_at ?? null;
            objModel.IdLink                             = data.link;
            objModel.PrestamoCollectedFecha             = data.loan_data?.collected_at ?? null;
            objModel.PrestamoImporteContrato            = data.loan_data?.contract_amount ?? 0;
            objModel.PrestamoContractEndFecha           = data.loan_data?.contract_end_date ?? "";
            objModel.PrestamoNumeroContrato             = data.loan_data?.contract_number ?? "";
            objModel.PrestamoContractStartFecha         = data.loan_data?.contract_start_date ?? "";
            objModel.PrestamoCuttingFecha               = data.loan_data?.cutting_date ?? "";
            objModel.PrestamoDiaCorte                   = data.loan_data?.cutting_day ?? "";
            objModel.PrestamoTarifaJson                 = JsonConvert.SerializeObject(data.loan_data?.fees ?? new List<Tarifa>());
            objModel.PrestamoTasaInteresJson            = JsonConvert.SerializeObject(data.loan_data?.interest_rates ?? new List<TasaInteres>());
            objModel.PrestamoLastPaymentFecha           = data.loan_data?.last_payment_date ?? "";
            objModel.PrestamoTipo                       = data.loan_data?.loan_type ?? "";
            objModel.PrestamoPagoMensual                = data.loan_data?.monthly_payment ?? 0;
            objModel.PrestamoSinPagoIntereses           = data.loan_data?.no_interest_payment ?? 0;
            objModel.PrestamoNumeroPlazosTotal          = Globals.ParseIntNull(data.loan_data?.number_of_installments_total ?? "0");
            objModel.PrestamoNumeroPlazosPendientes     = Globals.ParseIntNull(data.loan_data?.number_of_installments_outstanding ?? "0");
            objModel.PrestamoSaldoPendientePago         = data.loan_data?.outstanding_balance ?? 0;
            objModel.PrestamoPrincipalPendientePago     = data.loan_data?.outstanding_principal ?? 0;
            objModel.PrestamoDiaPago                    = data.loan_data?.payment_day ?? "";
            objModel.PrestamoPrincipal                  = data.loan_data?.principal ?? 0;
            objModel.CuentaNombre                       = data.name;
            objModel.CuentaNumero                       = data.number;
            objModel.CuentaIdentificacionPublicaNombre  = data.public_identification_name;
            objModel.CuentaIdentificacionPublicaValor   = data.public_identification_value;
            objModel.CuentasPorCobrarValorAnticipado    = data.receivables_data?.anticipated ?? 0;
            objModel.CuentasPorCobrarValorDisponible    = data.receivables_data?.available ?? 0;
            objModel.CuentasPorCobrarCollectedFecha     = data.receivables_data?.collected_at ?? null;
            objModel.CuentasPorCobrarValorActual        = data.receivables_data?.current ?? 0;
            objModel.CuentaTipo                         = data.type;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Cuentas.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
