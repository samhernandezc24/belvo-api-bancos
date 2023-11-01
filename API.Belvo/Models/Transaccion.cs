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
        public string IdExterno { get; set; }
        public DateTime AccountingFecha { get; set; }

        // Cuenta [Account]
        public string IdCuenta { get; set; }
        public string IdCuentaProductoBancario { get; set; }

        [Column(TypeName = "decimal(30, 2)")]
        public decimal? Monto { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? Saldo { get; set; }
        public string Categoria { get; set; }
        public DateTime CollectedFecha { get; set; }
        public DateTime TransaccionCreatedFecha { get; set; }
        public string MonedaCodigo { get; set; }
        public string Descripcion { get; set; }
        public string IdentificacionInterna { get; set; }
        public string Observaciones { get; set; }
        public string Referencia { get; set; }
        public string TransaccionEstatusName { get; set; }
        public string SubCategoria { get; set; }
        public string Tipo { get; set; }
        public string ValueFecha { get; set; }

        // Comerciante [Merchant]
        public string ComercianteNombre { get; set; }

        // TarjetaCredito [CreditCard]
        public string TarjetaCreditoCuentaNombre { get; set; }
        public string TarjetaCreditoTotalCuentaAnterior { get; set; }
        public DateTime? TarjetaCreditoCollectedFecha { get; set; }
    }
}
