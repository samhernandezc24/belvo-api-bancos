namespace API.Belvo.ViewModels
{
    public class BelvoInstitucionViewModel
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<InstitucionListResult> results { get; set; }
    }

    public class InstitucionListResult
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public string website { get; set; }
        public string display_name { get; set; }
        public string country_code { get; set; }
        public List<string> country_codes { get; set; }
        public string primary_color { get; set; }
        public string logo { get; set; }
        public string icon_logo { get; set; }
        public string text_logo { get; set; }
        public List<CampoFormulario> form_fields { get; set; }
        public List<Caracteristica> features { get; set; }
        public List<string> resources { get; set; }
        public string integration_type { get; set; }
        public string status { get; set; }
        public object openbanking_information { get; set; }
    }

    public class CampoFormulario
    {
        public string name { get; set; }
        public string type { get; set; }
        public string label { get; set; }
        public string validation { get; set; }
        public string placeholder { get; set; }
        public string validation_message { get; set; }
        public List<Valor> values { get; set; }
    }

    public class Caracteristica
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Valor
    {
        public string code { get; set; }
        public string label { get; set; }
        public string validation { get; set; }
        public string validation_message { get; set; }
        public string placeholder { get; set; }
    }
}
