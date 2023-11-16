namespace API.Belvo.ViewModels.Requests
{
    public class ReqCompleteRequestTransactions
    {
        public string session { get; set; }
        public string token { get; set; }
        public string link { get; set; }
        public bool save_data { get; set; } = true;
    }
}
