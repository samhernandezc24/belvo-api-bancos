using System.ComponentModel.DataAnnotations;
using Workcube.Generic;

namespace API.Belvo.Models
{
    public class Link : UserCreated
    {
        [Key]
        public string IdLink { get; set; }                  // GUID GENERADO POR BELVO HOMOLOGADO A WORKCUBE
        public string Institucion { get; set; }
        public string ModoAcceso { get; set; }
        public DateTime UltimoAccesoFecha { get; set; }
        public DateTime CreadoFecha { get; set; }
        public string IdUsuarioInstitucion { get; set; }
        public string LinkEstatusName { get; set; }
        public string CreadoPor { get; set; }
        public string TasaActualizacion { get; set; }
        public string AlmacenamientoCredenciales { get; set; }
        public string BuscarRecursos { get; set; }
        public string LinkVencimiento { get; set; }

        // ID ÚNICO DE USUARIO (ASPNETUSER) ESTA EN LA CLASE (USER CREATED) JUNTO AL NOMBRE
        public virtual List<Cuenta> Cuentas { get; set; }
        public virtual List<Transaccion> Transacciones { get; set; }
    }
}
