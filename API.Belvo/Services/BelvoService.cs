using API.Belvo.Libraries;
using API.Belvo.Persistence;

namespace API.Belvo.Services
{
    public class BelvoService
    {
        static string belvoApiUrl = "https://sandbox.belvo.com/";
        public readonly Context _context;

        // public static IEnumerable<dynamic> lstHeaders = new List<dynamic>().Append(new { name = "Authorization", value = "Basic N2E0NTUyNjUtYjVmNS00NmJkLTllNjUtYmVhYTg4NTg1MWU1OkRAeWxtYSNFaHpyVDM0bzUxVXZ6czJqQlVpQzhvcUEwTGxRZUN6bHlfWFU5alI4RkE0OV9kMVB0ZXJVOFVHTEM=" });

        public BelvoService (Context context)
        {
            _context = context;
        }

        // A
        #region ACCOUNTS

        public static async Task<dynamic> GetAccountsList(List<dynamic> headers)
        {
            try
            {
                return await WebServiceManager.Get(belvoApiUrl + "api/accounts", headers: headers);
            }
            catch (Exception e)
            {
                // Manejar la excepción.
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        public static async Task<dynamic> AccountsCreate(dynamic parameters)
        {
            var result = await WebServiceManager.Post(belvoApiUrl + "api/accounts", parameters);
            return result;
        }

        #endregion

        // L

        // T
    }
}
