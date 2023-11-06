using API.Belvo.Libraries;
using API.Belvo.Persistence;

namespace API.Belvo.Services
{
    public class BelvoService
    {
        static string belvoApiUrl = "https://sandbox.belvo.com/";

        public readonly Context _context;
        public static IEnumerable<dynamic> lstHeaders = new List<dynamic>().Append(new { name = "Authorization", value = "Basic N2E0NTUyNjUtYjVmNS00NmJkLTllNjUtYmVhYTg4NTg1MWU1OkRAeWxtYSNFaHpyVDM0bzUxVXZ6czJqQlVpQzhvcUEwTGxRZUN6bHlfWFU5alI4RkE0OV9kMVB0ZXJVOFVHTEM=" });

        public BelvoService (Context context)
        {
           _context = context;
        }

        // A
        #region ACCOUNTS
        /*
        |--------------------------------------------------------------------------
        | Obtiene una "Institucion" [GET]
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
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Recupera "Cuentas" de un "Link" [POST]
        |--------------------------------------------------------------------------
        |
        | Se recupera "Cuentas" de un "Link" existente.
        |
        */
        public static async Task<dynamic> AccountsRetrieveByLink(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Post(belvoApiUrl + "api/accounts", lstHeaders, objBodyParams);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Completa una solicitud de "Cuentas" [PATCH]
        |--------------------------------------------------------------------------
        |
        | Se utiliza para reanudar una sesión de recuperación de "Cuenta" que se detuvo
        | porque la institución requería un token MFA.
        |
        */
        public static async Task<dynamic> AccountsCompleteMFA(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(belvoApiUrl + "api/accounts", lstHeaders, objBodyParams);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Obtiene los datos de una "Cuenta" [GET]
        |--------------------------------------------------------------------------
        |
        | Nos devuelve los detalles de una "Cuenta" específica.
        |
        */
        public static async Task<dynamic> AccountsDetails(string id)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/accounts/" + id, lstHeaders);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Elimina una "Cuenta" [DELETE]
        |--------------------------------------------------------------------------
        |
        | Elimina una "Cuenta" específica y todas las transacciones y
        | propietarios asociados a la cuenta Belvo.
        |
        */
        public static async Task<dynamic> AccountsDelete(string id)
        {
            try
            {
                var result = await WebServiceManager.Delete(belvoApiUrl + "api/accounts/" + id, lstHeaders);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }
        #endregion

        // I
        #region INSTITUTIONS
        /*
        |--------------------------------------------------------------------------
        | Lista todas las "Instituciones" [GET]
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
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Obtiene una "Institucion" [GET]
        |--------------------------------------------------------------------------
        |
        | Nos devuelve los detalles de una "Institucion" específica.
        |
        */
        public static async Task<dynamic> InstitutionsDetails(string id)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/institutions/" + id, lstHeaders); 
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }
        #endregion

        // L
        #region LINKS
        /*
        |--------------------------------------------------------------------------
        | Lista todos los "Links" [GET]
        |--------------------------------------------------------------------------
        |
        | Se obtiene una lista paginada de todos los "Links" existentes en nuestra
        | cuenta de Belvo. Por defecto, devuelve hasta 100 resultados por página.
        |
        */
        public static async Task<dynamic> LinksList()
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/links", lstHeaders);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Registra un nuevo "Link" [POST]
        |--------------------------------------------------------------------------
        |
        | Se registra un nuevo "Link" con la cuenta de Belvo.
        |
        */
        public static async Task<dynamic> LinksCreate(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Post(belvoApiUrl + "api/links", lstHeaders, objBodyParams);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Completa una solicitud de "Link" [PATCH]
        |--------------------------------------------------------------------------
        |
        | Se utiliza para reanudar una sesión de registro de "Link" que se detuvo
        | porque la institución requería un token MFA.
        |
        */
        public static async Task<dynamic> LinksCompleteMFA(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(belvoApiUrl + "api/links", lstHeaders, objBodyParams);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Obtiene los datos de un "Link" [GET]
        |--------------------------------------------------------------------------
        |
        | Nos devuelve los detalles de un "Link" específico.
        |
        */
        public static async Task<dynamic> LinksDetails(string id)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/links/" + id, lstHeaders);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Cambia el modo de acceso de un "Link" [PATCH]
        |--------------------------------------------------------------------------
        |
        | Cambia el modo de acceso de un "Link" de único (single) a recurrente
        | (recurrent) o de recurrente a único.
        |
        | Nota: Cuando se cambia un "Link" de único a recurrente, sólo se actualizarán
        | al día siguiente en el intervalo programado.
        |
        */
        public static async Task<dynamic> LinksChangeAccessMode(string id, dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(belvoApiUrl + "api/links/" + id, lstHeaders, objBodyParams);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Actualiza las credenciales de un "Link" [PUT]
        |--------------------------------------------------------------------------
        |
        | Actualiza las credenciales de un "Link" específico. Si el "Link" actualizado
        | correctamente es recurrente, se activa automáticamente una actualización del
        | "Link". Si se encuentra datos nuevos, se recibirá un webhook de actualización
        | histórica.
        |
        */
        public static async Task<dynamic> LinksUpdateCredentials(string id, dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Put(belvoApiUrl + "api/links/" + id, lstHeaders, objBodyParams);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Elimina un "Link" [DELETE]
        |--------------------------------------------------------------------------
        |
        | Elimina un "Link" específico y todas las cuentas, transacciones y
        | propietarios asociados a la cuenta Belvo.
        |
        */
        public static async Task<dynamic> LinksDelete(string id)
        {
            try
            {
                var result = await WebServiceManager.Delete(belvoApiUrl + "api/links/" + id, lstHeaders);
                return result;
            }
            catch (Exception e)
            {                
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }
        #endregion

        // C
        #region CONSENTS
        /*
        |--------------------------------------------------------------------------
        | Lista todos los "Consentimientos" [GET]
        |--------------------------------------------------------------------------
        |
        | Se obtiene una lista paginada de todos los "Consentimientos" existentes
        | en nuestra cuenta de Belvo. Por defecto, devuelve hasta 100 resultados
        | por página.
        |
        */
        public static async Task<dynamic> ConsentsList(dynamic objQueryParams)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/consents", lstHeaders, objQueryParams);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Obtiene los datos de un "Consentimiento" [GET]
        |--------------------------------------------------------------------------
        |
        | Nos devuelve los detalles de un "Consentimiento" específico.
        |
        */
        public static async Task<dynamic> ConsentsDetails(string id)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/consents/" + id, lstHeaders);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }
        #endregion

        // T
        #region TRANSACTIONS
        /*
        |--------------------------------------------------------------------------
        | Lista todas las "Transacciones" [GET]
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
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Recupera transacciones para un "Link" [POST]
        |--------------------------------------------------------------------------
        |
        | Se recupera transacciones para una o más "Cuentas" desde un "Link" 
        | específico.
        |
        */
        public static async Task<dynamic> TransactionsRetrieveByLink(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Post(belvoApiUrl + "api/transactions", lstHeaders, objBodyParams);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Completa una solicitud de "Transaccion" [PATCH]
        |--------------------------------------------------------------------------
        |
        | Se utiliza para reanudar una sesión de recuperación de "Transaccion" que se 
        | detuvo porque la institución requería un token MFA.
        |
        */
        public static async Task<dynamic> TransactionsCompleteMFA(dynamic objBodyParams)
        {
            try
            {
                var result = await WebServiceManager.Patch(belvoApiUrl + "api/transactions", lstHeaders, objBodyParams);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Obtiene los datos de una "Transaccion" [GET]
        |--------------------------------------------------------------------------
        |
        | Nos devuelve los detalles de una "Transaccion" específica.
        |
        */
        public static async Task<dynamic> TransactionsDetails(string id)
        {
            try
            {
                var result = await WebServiceManager.Get(belvoApiUrl + "api/transactions/" + id, lstHeaders);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        /*
        |--------------------------------------------------------------------------
        | Elimina una "Transaccion" [DELETE]
        |--------------------------------------------------------------------------
        |
        | Elimina una "Transaccion" específica de la cuenta Belvo.
        |
        */
        public static async Task<dynamic> TransactionsDelete(string id)
        {
            try
            {
                var result = await WebServiceManager.Delete(belvoApiUrl + "api/transactions/" + id, lstHeaders);
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }
        #endregion
    }
}
