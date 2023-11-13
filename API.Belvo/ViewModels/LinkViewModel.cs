namespace API.Belvo.ViewModels
{
    public class LinkViewModel
    {
        public string IdLink { get; set; }
        public string Institucion { get; set; }
        public string ModoAcceso { get; set; }
        public string LinkEstatus { get; set; }
        public string TasaActualizacion { get; set; }
        public string CreadoPor { get; set; }
        public DateTime UltimoAccesoFecha { get; set; }
        public string IdExterno { get; set; }
        public DateTime CreadoFecha { get; set; }
        public string IdUsuarioInstitucion { get; set; }
        public string AlmacenamientoCredenciales { get; set; }
        public string LinkVencimiento { get; set; }
        public string BuscarRecursos { get; set; }
    }
}
