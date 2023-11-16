namespace API.Belvo.Libraries
{
    public class GlobalVariables
    {
        public static string belvoApiUrl = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ? "https://sandbox.belvo.com/" : "https://sandbox.belvo.com/";

        public static string value = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ? "N2E0NTUyNjUtYjVmNS00NmJkLTllNjUtYmVhYTg4NTg1MWU1OkRAeWxtYSNFaHpyVDM0bzUxVXZ6czJqQlVpQzhvcUEwTGxRZUN6bHlfWFU5alI4RkE0OV9kMVB0ZXJVOFVHTEM=" : "";

        public static IEnumerable<dynamic> lstHeaders = new List<dynamic>().Append( new { name = "Authorization", value = "Basic " + value } );
    }
}
