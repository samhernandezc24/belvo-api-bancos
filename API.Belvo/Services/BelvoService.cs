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
        public static async Task<CuentaListResult> RetrieveAccountsForLink(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Post(belvoApiUrl + "api/accounts", lstHeaders, objBodyParams);
                
                if (!result.isSuccessful) { throw new ArgumentException($"{result.statusCode} - No se pudieron obtener las cuentas."); }

                CuentaListResult accountData = JsonConvert.DeserializeObject<CuentaListResult>(result.body);

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
        public static async Task<dynamic> CompleteAccountsRequest(dynamic objBodyParams)
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
        public static async Task<dynamic> AccountsDetails(string id)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/accounts/" + id, lstHeaders);
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
        public static async Task<dynamic> AccountsDelete(string id)
        {
            try
            {
                var result = await WebServiceManager.Delete(belvoApiUrl + "api/accounts/" + id, lstHeaders);
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