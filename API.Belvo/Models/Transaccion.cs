using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workcube.Generic;

namespace API.Belvo.Models
{
    public class Transaccion : UserCreated
    {
        [Key]
        public string IdTransaccion { get; set; }                 

        // Cuenta [Account]
        public string IdCuenta { get; set; }
        public string IdExterno { get; set; }       // ID LINK GENERADO POR WORKCUBE
        public string IdLink { get; set; }          // ID LINK OBTENIDO API BELVO
        public string IdCuentaProductoBancario { get; set; }

        public DateTime RecoleccionFecha { get; set; }
        public DateTime CreadoFecha { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }

        // Comerciante [Merchant]
        public string ComercianteNombre { get; set; }

        public string Tipo { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal Monto { get; set; }
        public string Estatus { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal Saldo { get; set; }
        public string MonedaCodigo { get; set; }
        public string Referencia { get; set; }
        public string ValorFecha { get; set; }
        public string Descripcion { get; set; }
        public string Observaciones { get; set; }
        public DateTime ContableFecha { get; set; }
        public string IdentificacionInterna { get; set; }

        // DatosTarjetaCredito [CreditCardData]
        public DateTime? TarjetaCreditoRecoleccionFecha { get; set; }
        public string TarjetaCreditoFacturaNombre { get; set; }
        public string TarjetaCreditoFacturaEstatus { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? TarjetaCreditoFacturaMonto { get; set; }
        public string TarjetaCreditoTotalFacturaAnterior { get; set; }
    }
}
