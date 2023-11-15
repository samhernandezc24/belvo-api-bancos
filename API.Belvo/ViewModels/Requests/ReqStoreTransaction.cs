namespace API.Belvo.ViewModels.Requests
{
    public class ReqStoreTransaction
    {
        public string link { get; set; }
        public string account { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string token { get; set; }
        public bool save_data { get; set; } = true;
    }
}
