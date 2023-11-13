using API.Belvo.Libraries;
using API.Belvo.Persistence;

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
            catch (HttpRequestException httpEx)
            {
                throw new ArgumentException("Error en la petición HTTP: " + httpEx.Message, httpEx);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error inesperado: " + ex.Message, ex);
            }
        }
        #endregion
    }
}