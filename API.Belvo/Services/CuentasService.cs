using API.Belvo.Models;
using API.Belvo.Persistence;
using API.Belvo.ViewModels;
using API.Belvo.ViewModels.Requests;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Security.Claims;
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

        public async Task Create(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            ReqStoreLink objParamsLink = new ReqStoreLink
            {
                access_mode         = "recurrent",
                credentials_storage = "store",
                external_id         = "df96bf78-d9a2-455c-8b95-769f3b75b6a5",
                fetch_resources     = new List<string>() { "ACCOUNTS", "BALANCES", "INCOMES", "OWNERS", "TRANSACTIONS" },
                institution         = Globals.ToString(data.institutionName),
                password            = Globals.ToString(data.password),
                stale_in            = "365d",
                token               = Globals.ToString(data.token),
                username            = Globals.ToString(data.username),
            };

            LinkListResult objModelLink = await BelvoService.LinksStore(objParamsLink);
            await _linksService.Create(objModelLink);

            ReqStoreAccount objParamsAccount = new ReqStoreAccount
            {
                link        = objModelLink.id,
                token       = Globals.ToString(data.token),
                save_data   = true,
            };

            List<CuentaListResult> lstCuentas = await BelvoService.AccountsListForLink(objParamsAccount);
            var lstInstituciones = await BelvoService.InstitutionsList();

            foreach (CuentaListResult item in lstCuentas)
            {
                Cuenta objModel                             = new Cuenta();                
                objModel.IdCuenta                           = item.id;
                objModel.CuentaAgencia                      = item.agency;
                objModel.SaldoDisponible                    = item.balance_available;
                objModel.SaldoActual                        = item.balance_current;
                objModel.CuentaTipoSaldo                    = item.balance_type;
                objModel.IdProductoBancario                 = item.bank_product_id;
                objModel.CuentaCategoria                    = item.category;
                objModel.RecoleccionFecha                   = item.collected_at;
                objModel.CreadoFecha                        = item.created_at;
                objModel.CreditoRecoleccionFecha            = item.credit_data?.collected_at        ?? null;
                objModel.CreditoLimite                      = item.credit_data?.credit_limit        ?? 0;
                objModel.CreditoCorteFecha                  = item.credit_data?.cutting_date        ?? "";
                objModel.CreditoTasaInteres                 = item.credit_data?.interest_rate       ?? 0;
                objModel.CreditoSaldoUltimoPeriodo          = item.credit_data?.last_period_balance ?? 0;
                objModel.CreditoUltimoPagoFecha             = item.credit_data?.last_payment_date   ?? "";
                objModel.CreditoPagoMinimo                  = item.credit_data?.minimum_payment     ?? 0;
                objModel.CreditoPagoMensual                 = item.credit_data?.monthly_payment     ?? 0;
                objModel.CreditoProximoPagoFecha            = item.credit_data?.next_payment_date   ?? "";
                objModel.CreditoPagoSinInteres              = item.credit_data?.no_interest_payment ?? 0;
                objModel.MonedaCodigo                       = item.currency;
                objModel.FondosSaldo                        = item.funds_data?.balance      ?? 0;
                objModel.FondosRecoleccionFecha             = item.funds_data?.collected_at ?? null;
                objModel.FondosNombre                       = item.funds_data?.name         ?? "";
                objModel.FondosPorcentaje                   = item.funds_data?.percentage   ?? 0;
                objModel.FondosIdentificacionPublicaJson    = JsonConvert.SerializeObject(item.funds_data?.public_identifications ?? new List<IdentificacionPublica>());
                objModel.FondosTipo                         = item.funds_data?.type ?? "";
                objModel.InstitucionNombre                  = lstInstituciones.Where(x => x.name == (item.institution?.name ?? "")).FirstOrDefault()?.display_name ?? "";
                objModel.InstitucionTipo                    = item.institution_type;
                objModel.InstitucionCodigo                  = item.institution_code;
                objModel.CuentaIdentificacionInterna        = item.internal_identification;
                objModel.UltimoAccesoFecha                  = item.last_accessed_at ?? null;
                objModel.IdLink                             = item.link;
                objModel.PrestamoRecoleccionFecha           = item.loan_data?.collected_at          ?? null;
                objModel.PrestamoMontoContrato              = item.loan_data?.contract_amount       ?? 0;
                objModel.PrestamoContratoFinalizacionFecha  = item.loan_data?.contract_end_date     ?? "";
                objModel.PrestamoNumeroContrato             = item.loan_data?.contract_number       ?? "";
                objModel.PrestamoContratoInicioFecha        = item.loan_data?.contract_start_date   ?? "";
                objModel.PrestamoCorteFecha                 = item.loan_data?.cutting_date          ?? "";
                objModel.PrestamoDiaCorte                   = item.loan_data?.cutting_day           ?? "";
                objModel.PrestamoTarifaJson                 = JsonConvert.SerializeObject(item.loan_data?.fees ?? new List<Tarifa>());
                objModel.PrestamoTasaInteresJson            = JsonConvert.SerializeObject(item.loan_data?.interest_rates ?? new List<TasaInteres>());
                objModel.PrestamoUltimoPagoFecha            = item.loan_data?.last_payment_date     ?? "";
                objModel.PrestamoTipo                       = item.loan_data?.loan_type             ?? "";
                objModel.PrestamoPagoMensual                = item.loan_data?.monthly_payment       ?? 0;
                objModel.PrestamoPagoSinInteres             = item.loan_data?.no_interest_payment   ?? 0;
                objModel.PrestamoNumeroCuotasTotal          = Globals.ParseIntNull(item.loan_data?.number_of_installments_total ?? "0");
                objModel.PrestamoNumeroCuotasPendientes     = Globals.ParseIntNull(item.loan_data?.number_of_installments_outstanding ?? "0");
                objModel.PrestamoSaldoPendientePago         = item.loan_data?.outstanding_balance   ?? 0;
                objModel.PrestamoPrincipalPendientePago     = item.loan_data?.outstanding_principal ?? 0;
                objModel.PrestamoDiaPago                    = item.loan_data?.payment_day           ?? "";
                objModel.PrestamoPrincipal                  = item.loan_data?.principal             ?? 0;
                objModel.CuentaNombre                       = item.name;
                objModel.CuentaNumero                       = item.number;
                objModel.CuentaTipo                         = item.type;
                objModel.CuentaIdentificacionPublicaNombre  = item.public_identification_name;
                objModel.CuentaIdentificacionPublicaValor   = item.public_identification_value;
                objModel.CuentasPorCobrarAnticipado         = item.receivables_data?.anticipated    ?? 0;
                objModel.CuentasPorCobrarDisponible         = item.receivables_data?.available      ?? 0;
                objModel.CuentasPorCobrarRecoleccionFecha   = item.receivables_data?.collected_at   ?? null;
                objModel.CuentasPorCobrarActual             = item.receivables_data?.current ?? 0;
                // objModel.SetCreated(Globals.GetUser(user));

                _context.Cuentas.Add(objModel);
            }

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

            var objDataTableResult              = await objDataTableBuilder.build();
            List<CuentaViewModel> lstOriginal   = objDataTableResult.rows;
            List<dynamic> lstRows               = new List<dynamic>();

            lstOriginal.ForEach(x =>
            {
                lstRows.Add(new
                {
                    IdCuenta = x.IdCuenta,
                    IdLink   = x.IdLink,
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
            var objTransaction = _context.Database.BeginTransaction();

            string id = Globals.ParseGuid(data.idCuenta);
            Cuenta objModel = await Find(id) ?? throw new ArgumentException(String.Format("No se encontró la cuenta con el Id: {0}", id));

            if (objModel.Deleted) { throw new ArgumentException(String.Format("La cuenta con el Id {0} ya había sido eliminado previamente.", id)); }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Cuentas.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<Cuenta> Find(string id)
        {
            return await _context.Cuentas.FindAsync(id) ?? throw new ArgumentException(String.Format("No se encontró la cuenta con el Id: {0}", id));
        }

        public async Task<Cuenta> FindSelectorById(string id, string fields)
        {
            var cuenta = await _context.Cuentas.Where(x => x.IdCuenta == id).Select(Globals.BuildSelector<Cuenta, Cuenta>(fields)).FirstOrDefaultAsync();
            return cuenta ?? throw new ArgumentException(String.Format("No se encontró la cuenta con el Id: {0} o el campo especificado '{1}' no es válido en la búsqueda.", id, fields));
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Cuentas.AsNoTracking().Where(x => !x.Deleted).Select(x => new { x.IdCuenta, x.IdLink, x.CuentaNombre, x.InstitucionCodigo, x.InstitucionNombre }).OrderBy(x => x.InstitucionNombre).ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> List(string codigoERP)
        {
            return await _context.Cuentas.AsNoTracking().Where(x => !x.Deleted).Select(x => new { x.IdCuenta, x.IdLink, x.CuentaNombre }).ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListSelectorById(string id, string fields)
        {
            var cuenta = await _context.Cuentas.AsNoTracking().Where(x => !x.Deleted && x.IdCuenta == id).Select(Globals.BuildSelector<Cuenta, Cuenta>(fields)).ToListAsync<dynamic>();
            return cuenta ?? throw new ArgumentException(String.Format("No se encontró la cuenta con el Id: {0} o el campo especificado '{1}' no es válido en la búsqueda.", id, fields));
        }

        public async Task<List<dynamic>> UsuariosList()
        {
            var lstUsuarios = await _context.Cuentas
                .AsNoTracking()
                .Select(x => new
                {
                    IdCreatedUser = x.IdCreatedUser,
                    CreatedUserName = x.CreatedUserName,
                    IdUpdatedUser = x.IdUpdatedUser,
                    UpdatedUserName = x.UpdatedUserName,
                })
                .Distinct()
                .ToListAsync();

            var rows = lstUsuarios.SelectMany(x => new[]
            {
                new { Id = x.IdCreatedUser, NombreCompleto = x.CreatedUserName },
                new { Id = x.IdUpdatedUser, NombreCompleto = x.UpdatedUserName },
            })
            .GroupBy(x => x.Id)
            .Select(x => x.First())
            .OrderBy(x => x.NombreCompleto)
            .ToList<dynamic>();

            return rows;
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            string id       = Globals.ParseGuid(data.idCuenta);
            Cuenta objModel = await Find(id) ?? throw new ArgumentException(String.Format("No se encontró la cuenta con el Id: {0}", id));

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
            objModel.CuentaTipo                         = data.type;
            objModel.CuentaIdentificacionPublicaNombre  = data.public_identification_name;
            objModel.CuentaIdentificacionPublicaValor   = data.public_identification_value;
            objModel.CuentasPorCobrarAnticipado         = data.receivables_data?.anticipated    ?? 0;
            objModel.CuentasPorCobrarDisponible         = data.receivables_data?.available      ?? 0;
            objModel.CuentasPorCobrarRecoleccionFecha   = data.receivables_data?.collected_at   ?? null;
            objModel.CuentasPorCobrarActual             = data.receivables_data?.current        ?? 0;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Cuentas.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}