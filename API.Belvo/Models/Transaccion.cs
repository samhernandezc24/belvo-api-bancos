﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Workcube.Generic;

namespace API.Belvo.Models
{
    public class Transaccion : UserCreated
    {
        [Key]
        public string IdTransaccion { get; set; }           // GUID GENERADO POR WORKCUBE
        public string IdTransaccionBelvo { get; set; }      // ID GENERADO POR BELVO

        // Cuenta [Account]
        public string IdCuenta { get; set; }                // ID GENERADO POR BELVO
        public string IdLink { get; set; }                  // ID GENERADO POR BELVO
        public string IdCuentaProductoBancario { get; set; }

        public DateTime RecoleccionFecha { get; set; }
        public DateTime CreadoFecha { get; set; }
        public string TransaccionCategoria { get; set; }
        public string TransaccionSubCategoria { get; set; }

        // Comerciante [Merchant]
        public string ComercianteNombre { get; set; }

        public string TransaccionTipo { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal TransaccionMonto { get; set; }
        public string TransaccionEstatus { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal TransaccionSaldo { get; set; }
        public string MonedaCodigo { get; set; }
        public string TransaccionReferencia { get; set; }
        public string TransaccionValorFecha { get; set; }
        public string TransaccionDescripcion { get; set; }
        public string TransaccionObservaciones { get; set; }
        public DateTime TransaccionContableFecha { get; set; }
        public string TransaccionIdentificacionInterna { get; set; }

        // DatosTarjetaCredito [CreditCardData]
        public DateTime? TarjetaCreditoRecoleccionFecha { get; set; }
        public string TarjetaCreditoFacturaNombre { get; set; }
        public string TarjetaCreditoFacturaEstatus { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? TarjetaCreditoFacturaMonto { get; set; }
        public string TarjetaCreditoTotalFacturaAnterior { get; set; }
    }
}
