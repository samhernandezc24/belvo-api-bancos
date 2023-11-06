namespace API.Belvo.ViewModels
{
    public class LinkViewModel
    {
        public string IdLink { get; set; }
        public string Institucion { get; set; }
        public string ModoAcceso { get; set; }
        public string LinkEstatusName { get; set; }
        public string TasaActualizacion { get; set; }
        public string CreadoPor { get; set; }
        public DateTime LastAccessedFecha { get; set; }
        public string IdExternalBelvo { get; set; }
        public DateTime LinkCreatedFecha { get; set; }
        public string IdInstitucionUser { get; set; }
        public string AlmacenamientoCredenciales { get; set; }
        public string Vencimiento { get; set; }
        public bool IsFetchHistorical { get; set; }
        public string BuscarRecursos { get; set; }
    }
}
