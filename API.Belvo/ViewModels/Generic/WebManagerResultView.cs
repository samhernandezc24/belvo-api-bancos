namespace API.Belvo.ViewModels.Generic
{
    public class WebManagerResultView
    {
        public string content { get; set; }
        public byte[] bytes { get; set; }
        public string statusCode { get; set; }
        public bool isSuccessful { get; set; }
    }
}
