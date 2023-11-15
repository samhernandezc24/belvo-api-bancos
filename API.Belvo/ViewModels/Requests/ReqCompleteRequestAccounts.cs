namespace API.Belvo.ViewModels.Requests
{
    public class ReqCompleteRequestAccounts
    {
        public string session { get; set; }
        public string token { get; set; } = "WK2023ERP";
        public string link { get; set; }
        public bool save_data { get; set; } = true;
    }
}
