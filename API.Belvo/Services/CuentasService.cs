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
            var parameters = new
            {
                link = Globals.ParseGuid(data.idLink),
                token = "adasdffgaf<67fsdfe6d8fa7sd8a7syd87as",
                save_data = true,
            };         

            var result = await BelvoService.AccountsCreate(parameters);

            if (!result.isSuccessful) { throw new ArgumentException(result.statusCode + " - No se pudo guardar la cuenta"); }

            CuentaListResult accountData = JsonConvert.DeserializeObject<CuentaListResult>(result.content);

            var objTransaction = _context.Database.BeginTransaction();

            Cuenta objModel = new Cuenta();
            objModel.IdCuenta = Guid.NewGuid().ToString();
            objModel.CuentaAgencia = accountData.agency;
            objModel.SaldoActual = accountData.balance?.current ?? 0;
            objModel.SaldoDisponible = accountData.balance?.available ?? 0;
            objModel.CuentaSaldoTipo = accountData.balance_type;
            objModel.IdProductoBancario = accountData.bank_product_id;
            objModel.CuentaCategoria = accountData.category;
            objModel.CuentaCollectedFecha = accountData.collected_at;
            objModel.CuentaCreatedFecha = accountData.created_at;
            objModel.CreditoCollectedFecha = accountData.credit_data?.collected_at ?? null;
            objModel.CreditoLastPaymentFecha = accountData.credit_data?.last_payment_date ?? "";
            objModel.CreditoUltimoPeriodoSaldo = accountData.credit_data?.last_period_balance ?? 0;
            objModel.CreditoPagoMensual = accountData.credit_data?.monthly_payment ?? 0;
            objModel.CreditoNextPaymentFecha = accountData.credit_data?.next_payment_date ?? "";
            objModel.CreditoSinPagoIntereses = accountData.credit_data?.no_interest_payment ?? 0;
            objModel.CuentaMonedaCodigo = accountData.currency;
            objModel.FondosSaldo = accountData.funds_data?.balance ?? 0;
            objModel.FondosCollectedFecha = accountData.funds_data?.collected_at ?? null;
            objModel.FondosNombre = accountData.funds_data?.name ?? "";
            objModel.FondosPorcentaje = accountData.funds_data?.percentage ?? 0;
            objModel.FondosIdentificacionPublicaValor = JsonConvert.SerializeObject(data.funds_data.public_identifications);
            objModel.FondosTipo = accountData.funds_data?.type ?? "";
            objModel.IdExterno = accountData.id;
            objModel.InstitucionNombre = accountData.institution?.name ?? "";
            objModel.InstitucionTipo = accountData.institution?.type ?? "";
            objModel.InstitucionCodigo = accountData.institution_code;
            objModel.CuentaIdentificacionInterna = accountData.internal_identification;
            objModel.CuentaLastAccessedFecha = accountData.last_accessed_at ?? null;
            objModel.IdLink = accountData.link;
            objModel.PrestamoCollectedFecha = accountData.loan_data?.collected_at ?? null;
            objModel.PrestamoImporteContrato = accountData.loan_data?.contract_amount ?? 0;
            objModel.PrestamoContractEndFecha = accountData.loan_data?.contract_end_date ?? "";
            objModel.PrestamoNumeroContrato = accountData.loan_data?.contract_number ?? "";
            objModel.PrestamoContractStartFecha = accountData.loan_data?.contract_start_date ?? "";
            objModel.PrestamoCuttingFecha = accountData.loan_data?.cutting_day ?? "";
            objModel.PrestamoTarifaJson = JsonConvert.SerializeObject(accountData.loan_data?.fees ?? new List<Tarifa>());
            objModel.PrestamoTasaInteresJson = JsonConvert.SerializeObject(accountData.loan_data?.interest_rates ?? new List<TasaInteres>());
            objModel.PrestamoTipo = accountData.loan_data?.loan_type ?? "";
            objModel.PrestamoPagoMensual = accountData.loan_data?.monthly_payment ?? 0;
            objModel.PrestamoNumeroPlazosPendientes = Globals.ParseIntNull(accountData.loan_data?.number_of_installments_outstanding ?? "0");
            objModel.PrestamoNumeroPlazosTotal = Globals.ParseIntNull(accountData.loan_data?.number_of_installments_total ?? "0");
            objModel.PrestamoSaldoPendientePago = accountData.loan_data?.outstanding_balance ?? 0;
            objModel.PrestamoPrincipalPendientePago = accountData.loan_data?.outstanding_principal ?? 0;
            objModel.PrestamoDiaPago = accountData.loan_data?.payment_day ?? "";
            objModel.PrestamoPrincipal = accountData.loan_data?.principal ?? 0;
            objModel.CuentaNombre = accountData.name;
            objModel.CuentaNumero = accountData.number;
            objModel.CuentaIdentificacionPublicaNombre = accountData.public_identification_name;
            objModel.CuentaIdentificacionPublicaValor = accountData.public_identification_value;
            objModel.CuentasPorCobrarValorAnticipado = accountData.receivables_data?.anticipated ?? 0;
            objModel.CuentasPorCobrarValorDisponible = accountData.receivables_data?.available ?? 0;
            objModel.CuentasPorCobrarCollectedFecha = accountData.receivables_data?.collected_at ?? null;
            objModel.CuentasPorCobrarValorActual = accountData.receivables_data?.current ?? 0;

            _context.Cuentas.Add(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> DataSource(dynamic data)
        {
            IQueryable<CuentaViewModel> lstItems = DataSourceExpresion(data);
            DataSourceBuilder<CuentaViewModel> objDataTableBuilder = new DataSourceBuilder<CuentaViewModel>(data, lstItems);

            var objDataTableResult = await objDataTableBuilder.build();
            List<CuentaViewModel> lstOriginal = objDataTableResult.rows;
            List<dynamic> lstRows = new List<dynamic>();

            lstOriginal.ForEach(x =>
            {
                lstRows.Add(new
                {
                    IdCuenta = x.IdCuenta,
                    IdLink = x.IdLink,
                });
            });

            var objReturn = new
            {
                rows = lstRows,
                count = objDataTableResult.count,
                length = objDataTableResult.length,
                pages = objDataTableResult.pages,
                page = objDataTableResult.page,
            };

            return objReturn;
        }

        public IQueryable<CuentaViewModel> DataSourceExpresion(dynamic data)
        {
            // INCLUDES
            IQueryable<CuentaViewModel> lstItems;

            // APLICAR FILTROS DINAMICOS
            // FILTROS
            var filters = new Dictionary<string, Func<string, Expression<Func<Cuenta, bool>>>>
            {
                {"CreatedAspNetUser.Id",    (strValue) => item => item.IdCreatedUser    == strValue},
                {"UpdatedAspNetUser.Id",    (strValue) => item => item.IdUpdatedUser    == strValue}
            };

            // FILTROS MULTIPLE
            var filtersMultiple = new Dictionary<string, Func<string, Expression<Func<Cuenta, bool>>>> { };

            // FILTROS FECHAS
            DateTime? dateFrom = SourceExpression<Cuenta>.Date((string)data.dateFrom);
            DateTime? dateTo = SourceExpression<Cuenta>.Date((string)data.dateTo);

            var dates = new Dictionary<string, DateExpression<Cuenta>>()
            {
                { "CreatedFecha", new DateExpression<Cuenta>{ dateFrom = item => item.CreatedFecha.Date >= dateFrom, dateTo = item => item.CreatedFecha.Date <= dateTo } },
                { "UpdatedFecha", new DateExpression<Cuenta>{ dateFrom = item => item.UpdatedFecha.Date >= dateFrom, dateTo = item => item.UpdatedFecha.Date <= dateTo } }
            };

            Expression<Func<Cuenta, bool>> ExpFullWhere = SourceExpression<Cuenta>.GetExpression(data, filters, dates, filtersMultiple);

            // ORDER BY
            var orderColumn = Globals.ToString(data.sort.column);
            var orderDirection = Globals.ToString(data.sort.direction);

            Expression<Func<Cuenta, object>> sortExpression;
            switch (orderColumn)
            {
                case "createdUserName": sortExpression = (x => x.CreatedUserName); break;
                case "createdFecha": sortExpression = (x => x.CreatedFecha); break;
                case "updatedUserName": sortExpression = (x => x.UpdatedUserName); break;
                case "updatedFecha": sortExpression = (x => x.UpdatedFecha); break;
                default: sortExpression = (x => x.CreatedFecha); break;
            }

            List<string> columns = Globals.GetArrayColumns(data);

            columns.Add("IdCuenta");
            columns.Add("IdCreatedUser");
            columns.Add("CreatedUserName");
            columns.Add("IdUpdatedUser");
            columns.Add("UpdatedUserName");

            string strcolumns = Globals.GetStringColumns(columns);

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
                        .Select(Globals.BuildSelector<Cuenta, Cuenta>(strcolumns))
                        .ProjectTo<CuentaViewModel>(_mapper.ConfigurationProvider);

            return lstItems;
        }

        public async Task Delete(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            string id = Globals.ParseGuid(data.idCuenta);
            Cuenta objModel = await Find(id);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado la cuenta."); }
            if (objModel.Deleted) { throw new ArgumentException("La cuenta ya ha sido eliminada anteriormente."); }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Cuentas.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<Cuenta> Find(string id)
        {
            return await _context.Cuentas.FindAsync(id);
        }

        public async Task<Cuenta> FindSelectorById(string id, string fields)
        {
            return await _context.Cuentas.Where(x => x.IdCuenta == id).Select(Globals.BuildSelector<Cuenta, Cuenta>(fields)).FirstOrDefaultAsync();
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

            string id = Globals.ParseGuid(data.idCuenta);
            Cuenta objModel = await Find(id);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado la cuenta."); }

            objModel.CuentaAgencia = data.agency;
            objModel.SaldoActual = data.balance?.current ?? 0;
            objModel.SaldoDisponible = data.balance?.available ?? 0;
            objModel.CuentaSaldoTipo = data.balance_type;
            objModel.IdProductoBancario = data.bank_product_id;
            objModel.CuentaCategoria = data.category;
            objModel.CuentaCollectedFecha = data.collected_at;
            objModel.CuentaCreatedFecha = data.created_at;
            objModel.CreditoCollectedFecha = data.credit_data?.collected_at ?? null;
            objModel.CreditoLastPaymentFecha = data.credit_data?.last_payment_date ?? "";
            objModel.CreditoUltimoPeriodoSaldo = data.credit_data?.last_period_balance ?? 0;
            objModel.CreditoPagoMensual = data.credit_data?.monthly_payment ?? 0;
            objModel.CreditoNextPaymentFecha = data.credit_data?.next_payment_date ?? "";
            objModel.CreditoSinPagoIntereses = data.credit_data?.no_interest_payment ?? 0;
            objModel.CuentaMonedaCodigo = data.currency;
            objModel.FondosSaldo = data.funds_data?.balance ?? 0;
            objModel.FondosCollectedFecha = data.funds_data?.collected_at ?? null;
            objModel.FondosNombre = data.funds_data?.name ?? "";
            objModel.FondosPorcentaje = data.funds_data?.percentage ?? 0;
            objModel.FondosIdentificacionPublicaValor = JsonConvert.SerializeObject(data.funds_data.public_identifications);
            objModel.FondosTipo = data.funds_data?.type ?? "";
            objModel.IdExterno = data.id;
            objModel.InstitucionNombre = data.institution?.name ?? "";
            objModel.InstitucionTipo = data.institution?.type ?? "";
            objModel.InstitucionCodigo = data.institution_code;
            objModel.CuentaIdentificacionInterna = data.internal_identification;
            objModel.CuentaLastAccessedFecha = data.last_accessed_at ?? null;
            objModel.IdLink = data.link;
            objModel.PrestamoCollectedFecha = data.loan_data?.collected_at ?? null;
            objModel.PrestamoImporteContrato = data.loan_data?.contract_amount ?? 0;
            objModel.PrestamoContractEndFecha = data.loan_data?.contract_end_date ?? "";
            objModel.PrestamoNumeroContrato = data.loan_data?.contract_number ?? "";
            objModel.PrestamoContractStartFecha = data.loan_data?.contract_start_date ?? "";
            objModel.PrestamoCuttingFecha = data.loan_data?.cutting_day ?? "";
            objModel.PrestamoTarifaJson = JsonConvert.SerializeObject(data.loan_data?.fees ?? new List<Tarifa>());
            objModel.PrestamoTasaInteresJson = JsonConvert.SerializeObject(data.loan_data?.interest_rates ?? new List<TasaInteres>());
            objModel.PrestamoTipo = data.loan_data?.loan_type ?? "";
            objModel.PrestamoPagoMensual = data.loan_data?.monthly_payment ?? 0;
            objModel.PrestamoNumeroPlazosPendientes = Globals.ParseIntNull(data.loan_data?.number_of_installments_outstanding ?? "0");
            objModel.PrestamoNumeroPlazosTotal = Globals.ParseIntNull(data.loan_data?.number_of_installments_total ?? "0");
            objModel.PrestamoSaldoPendientePago = data.loan_data?.outstanding_balance ?? 0;
            objModel.PrestamoPrincipalPendientePago = data.loan_data?.outstanding_principal ?? 0;
            objModel.PrestamoDiaPago = data.loan_data?.payment_day ?? "";
            objModel.PrestamoPrincipal = data.loan_data?.principal ?? 0;
            objModel.CuentaNombre = data.name;
            objModel.CuentaNumero = data.number;
            objModel.CuentaIdentificacionPublicaNombre = data.public_identification_name;
            objModel.CuentaIdentificacionPublicaValor = data.public_identification_value;
            objModel.CuentasPorCobrarValorAnticipado = data.receivables_data?.anticipated ?? 0;
            objModel.CuentasPorCobrarValorDisponible = data.receivables_data?.available ?? 0;
            objModel.CuentasPorCobrarCollectedFecha = data.receivables_data?.collected_at ?? null;
            objModel.CuentasPorCobrarValorActual = data.receivables_data?.current ?? 0;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Cuentas.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
