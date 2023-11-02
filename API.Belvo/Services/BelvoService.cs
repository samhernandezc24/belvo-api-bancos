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
        public static async Task<dynamic> GetAccountsList()
        {
            try
            {
                return await WebServiceManager.Get(belvoApiUrl + "api/accounts", lstHeaders);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        public static async Task<dynamic> AccountsStore(dynamic parameters)
        {
            try
            {
                return await WebServiceManager.Post(belvoApiUrl + "api/accounts", parameters);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }
        #endregion

        // I
        #region INSTITUTIONS
        public static async Task<dynamic> GetInstitutionsList()
        {
            try
            {
                return await WebServiceManager.Get(belvoApiUrl + "api/institutions", lstHeaders);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        public static async Task<dynamic> GetInstitutionsDetails(string id)
        {
            try
            {
                return await WebServiceManager.Get(belvoApiUrl + "api/institutions/" + id, lstHeaders);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }
        #endregion

        // L
        #region LINKS
        public static async Task<dynamic> GetLinksList()
        {
            try
            {
                return await WebServiceManager.Get(belvoApiUrl + "api/links", lstHeaders);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }

        public static async Task<dynamic> LinksNew(dynamic objParameters)
        {
            try
            {
                return await WebServiceManager.Post(belvoApiUrl + "api/links", lstHeaders, objParameters);
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message + e.StackTrace);
            }
        }
        #endregion

        // T
    }
}
