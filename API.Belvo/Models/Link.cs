using System.ComponentModel.DataAnnotations;
using Workcube.Generic;

namespace API.Belvo.Models
{
    public class Link : UserCreated
    {
        [Key]
        public string IdLink { get; set; }                  // GUID GENERADO POR WORKCUBE
        public string IdLinkBelvo { get; set; }             // ID GENERADO POR BELVO
        public string Institucion { get; set; }
        public string ModoAcceso { get; set; }
        public string Estatus { get; set; }
        public string TasaActualizacion { get; set; }
        public string CreadoPor { get; set; }
        public DateTime UltimoAccesoFecha { get; set; }
        public string IdExterno { get; set; }               // ID ÚNICO DE USUARIO (ASP NET USER)
        public DateTime CreadoFecha { get; set; }
        public string IdUsuarioInstitucion { get; set; }
        public string AlmacenamientoCredenciales { get; set; }
        public string Vencimiento { get; set; }
        public string BuscarRecursos { get; set; }

        //public virtual List<Cuenta> Cuentas { get; set; }
    }
}
