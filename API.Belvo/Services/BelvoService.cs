using API.Belvo.Libraries;
using API.Belvo.Models;
using API.Belvo.Persistence;
using API.Belvo.ViewModels;
using Newtonsoft.Json;

namespace API.Belvo.Services
{
    public class BelvoService
    {
        static string belvoApiUrl = "https://sandbox.belvo.com/";

        public readonly Context _context;
        public static IEnumerable<dynamic> lstHeaders = new List<dynamic>().Append(new { name = "Authorization", value = "Basic N2E0NTUyNjUtYjVmNS00NmJkLTllNjUtYmVhYTg4NTg1MWU1OkRAeWxtYSNFaHpyVDM0bzUxVXZ6czJqQlVpQzhvcUEwTGxRZUN6bHlfWFU5alI4RkE0OV9kMVB0ZXJVOFVHTEM=" });

        public BelvoService(Context context)
        {
            _context = context;
        }

        // A
        #region ACCOUNTS
        /*
        |--------------------------------------------------------------------------
        | [GET] Lista de todas las "Cuentas"
        |--------------------------------------------------------------------------
        |
        | Se obtiene una lista paginada de todas las "Cuentas" existentes en
        | nuestra cuenta de Belvo. Por defecto, devuelve hasta 100 resultados por
        | página.
        |
        */
        public static async Task<dynamic> AccountsList()
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/accounts", lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [POST] Recupera las cuentas de un "Link"
        |--------------------------------------------------------------------------
        |
        | Se recupera las "Cuentas" de un "Link" existente.
        |
        */
        public static async Task<CuentaListResult> AccountsRetrieveForLink(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Post(belvoApiUrl + "api/accounts", lstHeaders, objBodyParams);
                
                if (!result.isSuccessful) { throw new ArgumentException($"{result.statusCode} - No se pudieron obtener las cuentas para su guardado."); }

                CuentaListResult accountData = JsonConvert.DeserializeObject<CuentaListResult>(result.content);

                return accountData;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [PATCH] Completa una solicitud de "Cuentas"
        |--------------------------------------------------------------------------
        |
        | Se utiliza para reanudar una sesión de recuperación de "Cuentas" que se
        | detuvo porque la institución requería un token MFA.
        |
        */
        public static async Task<dynamic> AccountsCompleteRequest(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(belvoApiUrl + "api/accounts", lstHeaders, objBodyParams);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [GET] Obtiene los datos de una "Cuenta"
        |--------------------------------------------------------------------------
        |
        | Obtiene los detalles de una "Cuenta" específica.
        |
        */
        public static async Task<dynamic> AccountsDetails(string Id)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/accounts/" + Id, lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [DELETE] Elimina una "Cuenta"
        |--------------------------------------------------------------------------
        |
        | Elimina una "Cuenta" específica y todas las transacciones asociadas, así
        | como propietarios, de la cuenta Belvo.
        |
        */
        public static async Task<dynamic> AccountsDelete(string Id)
        {
            try
            {
                var result = await WebServiceManager.Delete(belvoApiUrl + "api/accounts/" + Id, lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }
        #endregion

        // I
        #region INSTITUTIONS
        /*
        |--------------------------------------------------------------------------
        | [GET] Lista de todas las "Instituciones"
        |--------------------------------------------------------------------------
        |
        | Se obtiene una lista paginada de todas las "Instituciones" existentes en
        | nuestra cuenta de Belvo. Por defecto, devuelve hasta 100 resultados por
        | página.
        |
        */
        public static async Task<dynamic> InstitutionsList()
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/institutions", lstHeaders);

                if (!result.isSuccessful) { throw new ArgumentException($"{result.statusCode} - No se pudieron obtener las instituciones."); }

                BelvoInstitucionViewModel objInstitucionResult = JsonConvert.DeserializeObject<BelvoInstitucionViewModel>(result.content);

                return objInstitucionResult.results.Where(x => x.type == "bank").ToList();
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [GET] Obtiene los datos de una "Institución"
        |--------------------------------------------------------------------------
        |
        | Obtiene los detalles de una "Institución" específica.
        |
        */
        public static async Task<dynamic> InstitutionsDetails(string Id)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/institutions/" + Id, lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }
        #endregion

        // L
        #region LINKS
        /*
        |--------------------------------------------------------------------------
        | [GET] Lista de todos las "Links"
        |--------------------------------------------------------------------------
        |
        | Se obtiene una lista paginada de todas los "Links" existentes en
        | nuestra cuenta de Belvo. Por defecto, devuelve hasta 100 resultados por
        | página.
        |
        */
        public static async Task<dynamic> LinksList()
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/links", lstHeaders);

                if (!result.isSuccessful) { throw new ArgumentException($"{result.statusCode} - No se pudieron obtener los links."); }

                LinkListResult linkData = JsonConvert.DeserializeObject<LinkListResult>(result.content);

                return linkData;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [POST] Registra un nuevo "Link"
        |--------------------------------------------------------------------------
        |
        | Se registra un nuevo "Link" con nuestra cuenta de Belvo.
        |
        */
        public static async Task<LinkListResult> LinksNew(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Post(belvoApiUrl + "api/links", lstHeaders, objBodyParams);

                if (!result.isSuccessful) { throw new ArgumentException($"{result.statusCode} - No se pudo guardar el link."); }

                LinkListResult linkData = JsonConvert.DeserializeObject<LinkListResult>(result.content);

                return linkData;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

       /*
       |--------------------------------------------------------------------------
       | [PATCH] Completa una solicitud de "Links"
       |--------------------------------------------------------------------------
       |
       | Se utiliza para reanudar una sesión de registro de "Links" que se
       | detuvo porque la institución requería un token MFA.
       |
       */
        public static async Task<dynamic> LinksCompleteRequest(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(belvoApiUrl + "api/links", lstHeaders, objBodyParams);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [GET] Obtiene los datos de un "Link"
        |--------------------------------------------------------------------------
        |
        | Obtiene los detalles de un "Link" específico.
        |
        */
        public static async Task<dynamic> LinksDetails(string Id)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/links/" + Id, lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [PATCH] Cambia el modo de acceso de un "Link"
        |--------------------------------------------------------------------------
        |
        | Cambia el modo de acceso de un "Link" de único (single) a recurrente
        | (recurrent) o de recurrente a único.
        |
        | Nota: Cuando se cambia un "Link" de único a recurrente, sólo se
        | actualizarán al día siguiente en el intervalo programado.
        |
        */
        public static async Task<dynamic> LinksChangeAccessMode(string Id, dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(belvoApiUrl + "api/links/" + Id, lstHeaders, objBodyParams);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [PUT] Cambia el modo de acceso de un "Link"
        |--------------------------------------------------------------------------
        |
        | Cambia el modo de acceso de un "Link" de único (single) a recurrente
        | (recurrent) o de recurrente a único.
        |
        | Nota: Cuando se cambia un "Link" de único a recurrente, sólo se
        | actualizarán al día siguiente en el intervalo programado.
        |
        */
        public static async Task<dynamic> LinksUpdateCredentials(string Id, dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Put(belvoApiUrl + "api/links/" + Id, lstHeaders, objBodyParams);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [DELETE] Elimina un "Link"
        |--------------------------------------------------------------------------
        |
        | Elimina un "Link" específico y todas las cuentas, transacciones asociadas, así
        | como propietarios, de la cuenta Belvo.
        |
        */
        public static async Task<dynamic> LinksDelete(string Id)
        {
            try
            {
                var result = await WebServiceManager.Delete(belvoApiUrl + "api/links/" + Id, lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }
        #endregion

        // T
        #region TRANSACTIONS
        /*
        |--------------------------------------------------------------------------
        | [GET] Lista de todas las "Transacciones"
        |--------------------------------------------------------------------------
        |
        | Se obtiene una lista paginada de todas las "Transacciones" existentes en
        | nuestra cuenta de Belvo. Por defecto, devuelve hasta 100 resultados por
        | página.
        |
        */
        public static async Task<dynamic> TransactionsList(dynamic objQueryParams)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/transactions", lstHeaders, objQueryParams);

                if (!result.isSuccessful) { throw new ArgumentException($"{result.statusCode} - No se pudieron obtener las transacciones."); }

                TransaccionListResult transactionData = JsonConvert.DeserializeObject<TransaccionListResult>(result.content);

                return transactionData;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [POST] Recupera las transacciones de un "Link"
        |--------------------------------------------------------------------------
        |
        | Se recupera las "Transacciones" de una o más "Cuentas" desde un "Link" 
        | existente.
        |
        */
        public static async Task<TransaccionListResult> TransactionsRetrieveForLink(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Post(belvoApiUrl + "api/transactions", lstHeaders, objBodyParams);

                if (!result.isSuccessful) { throw new ArgumentException($"{result.statusCode} - No se pudieron obtener las transacciones de la cuenta para su guardado."); }

                TransaccionListResult transactionData = JsonConvert.DeserializeObject<TransaccionListResult>(result.content);

                return transactionData;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

       /*
       |--------------------------------------------------------------------------
       | [PATCH] Completa una solicitud de "Transacciones"
       |--------------------------------------------------------------------------
       |
       | Se utiliza para reanudar una sesión de registro de "Transacciones" que se
       | detuvo porque la institución requería un token MFA.
       |
       */
        public static async Task<dynamic> TransactionsCompleteRequest(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(belvoApiUrl + "api/transactions", lstHeaders, objBodyParams);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [GET] Obtiene los datos de una "Transaccion"
        |--------------------------------------------------------------------------
        |
        | Obtiene los detalles de una "Transaccion" específica.
        |
        */
        public static async Task<dynamic> TransactionsDetails(string Id)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/transactions/" + Id, lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | [DELETE] Elimina una "Transaccion"
        |--------------------------------------------------------------------------
        |
        | Elimina una "Transaccion" específica de la cuenta Belvo.
        |
        */
        public static async Task<dynamic> TransactionsDelete(string Id)
        {
            try
            {
                var result = await WebServiceManager.Delete(belvoApiUrl + "api/transactions/" + Id, lstHeaders);
                return result;
            }
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Ha ocurrido un error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ha ocurrido un error inesperado: " + ex.Message, ex);
            }
        }
        #endregion
    }
}