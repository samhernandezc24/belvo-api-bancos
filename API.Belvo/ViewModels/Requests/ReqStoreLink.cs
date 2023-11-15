namespace API.Belvo.ViewModels.Requests
{
    public class ReqStoreLink
    {
        public string institution { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string external_id { get; set; }
        public string token { get; set; } = "WK2023ERP";
        public string access_mode { get; set; } = "recurrent";
        public List<string> fetch_resources { get; set; } = new List<string>() { "ACCOUNTS", "BALANCES", "INCOMES", "OWNERS", "TRANSACTIONS" };
        public string credentials_storage { get; set; } = "store";
        public string stale_in { get; set; } = "365d";
    }
}
