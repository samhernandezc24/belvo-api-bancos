using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workcube.Generic;

namespace API.Belvo.Models
{
    public class Transaccion : UserCreated
    {
        [Key]
        public string IdTransaccion { get; set; }               // GUID GENERADO POR BELVO HOMOLOGADO A WORKCUBE
        public string TransaccionIdentificacionInterna { get; set; }

        // Cuenta [Account]
        public virtual Cuenta Cuenta { get; set; }
        public string IdCuenta { get; set; }                    // ID GENERADO / OBTENIDO DE BELVO
        public virtual Link Link { get; set; }
        public string IdLink { get; set; }                      // ID GENERADO / OBTENIDO DE BELVO
        public string IdCuentaProductoBancario { get; set; }

        public DateTime RecoleccionFecha { get; set; }
        public DateTime CreadoFecha { get; set; }
        public string TransaccionValorFecha { get; set; }
        public DateTime TransaccionContableFecha { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal TransaccionMonto { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal TransaccionSaldo { get; set; }
        public string MonedaCodigo { get; set; }
        public string TransaccionDescripcion { get; set; }
        public string TransaccionObservaciones { get; set; }

        // Comerciante [Merchant]
        public string ComercianteNombre { get; set; }

        public string TransaccionCategoria { get; set; }
        public string TransaccionSubCategoria { get; set; }
        public string TransaccionReferencia { get; set; }
        public string TransaccionTipo { get; set; }
        public string TransaccionEstatusName { get; set; }

        // DatosTarjetaCredito [CreditCardData]
        public DateTime? TarjetaCreditoRecoleccionFecha { get; set; }
        public string TarjetaCreditoFacturaNombre { get; set; }
        public string TarjetaCreditoFacturaEstatusName { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? TarjetaCreditoFacturaMonto { get; set; }
        public string TarjetaCreditoTotalFacturaAnterior { get; set; }
    }
}
