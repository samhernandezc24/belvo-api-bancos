namespace API.Belvo.ViewModels
{
    public class BelvoLinkViewModel
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<LinkListResult> results { get; set; }
    }

    public class LinkListResult
    {
        public string id { get; set; }
        public string institution { get; set; }
        public string access_mode { get; set; }
        public DateTime last_accessed_at { get; set; }
        public DateTime created_at { get; set; }
        public string external_id { get; set; }
        public string institution_user_id { get; set; }
        public string status { get; set; }
        public string created_by { get; set; }
        public string refresh_rate { get; set; }
        public string credentials_storage { get; set; }
        public bool fetch_historical { get; set; }
        public List<string> fetch_resources { get; set; }
        public string stale_in { get; set; }
    }
}
