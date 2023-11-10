using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Workcube.Generic;

namespace API.Belvo.Models
{
    public class Cuenta : UserCreated
    {
        [Key]
        public string IdCuenta { get; set; }
        public string IdExterno { get; set; }   // ID LINK GENERADOR WORKCUBE
        public string IdLink { get; set; }      // ID LINK OBTENIDO API BELVO

        // Institucion [Institution]
        public string InstitucionNombre { get; set; }
        public string InstitucionTipo { get; set; }
        public string InstitucionCodigo { get; set; }

        public DateTime RecoleccionFecha { get; set; }
        public DateTime CreadoFecha { get; set; }
        public string CuentaNombre { get; set; }
        public string CuentaTipo { get; set; }
        public string CuentaAgencia { get; set; }
        public string CuentaNumero { get; set; }

        // Saldo [Balance]
        [Column(TypeName = "decimal(30, 2)")]
        public decimal SaldoActual { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal SaldoDisponible { get; set; }

        public string CuentaCategoria { get; set; }
        public string CuentaMonedaCodigo { get; set; }

        // DatosPrestamo [LoanData]
        // DatosPrestamo [LoanData] => Tarifa [Fees]
        public string PrestamoTarifaJson { get; set; }

        public string PrestamoTipo { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoPrincipal { get; set; }
        public string PrestamoDiaCorte { get; set; }
        public string PrestamoCorteFecha { get; set; }
        public DateTime PrestamoRecoleccionFecha { get; set; }

        // DatosPrestamo [LoanData] => TasaInteres [InterestRates]
        public string PrestamoTasaInteresNombre { get; set; }
        public string PrestamoTasaInteresTipo { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal PrestamoTasaInteresValor { get; set; }

        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoMontoContrato { get; set; }
        public string PrestamoNumeroContrato { get; set; }
        public string PrestamoContratoInicioFecha { get; set; }
        public string PrestamoContratoFinFecha { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoPagoMensual { get; set; }
        public string PrestamoDiaPago { get; set; }
        public string PrestamoUltimoPagoFecha { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoSaldoPendientePago { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoPrincipalPendientePago { get; set; }
        public string PrestamoNumeroCuotasTotal { get; set; }
        public string PrestamoNumeroCuotasPendientes { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoPagoSinInteres { get; set; }

        // DatosCredito [CreditData]
        public DateTime CreditoRecoleccionFecha { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CreditoLimite { get; set; }
        public string CreditoCorteFecha { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CreditoTasaInteres { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal CreditoPagoMinimo { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CreditoPagoMensual { get; set; }
        public string CreditoUltimoPagoFecha { get; set; }
        public string CreditoProximoPagoFecha { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CreditoSaldoUltimoPeriodo { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CreditoPagoSinInteres { get; set; }

        public string CuentaTipoSaldo { get; set; }
        public string CuentaIdProductionBancario { get; set; }
        public DateTime? CuentaUltimoAccesoFecha { get; set; }
        public string CuentaIdentificacionInterna { get; set; }
        public string CuentaIdentificacionPublicaNombre { get; set; }
        public string CuentaIdentificacionPublicaValor { get; set; }

        // DatosFondo [FundsData]
        public DateTime? FondosRecoleccionFecha { get; set; }
        public string FondosNombre { get; set; }
        public string FondosTipo { get; set; }

        // DatosFondo [FundsData] => IdentificacionPublica [PublicIdentifications]
        public string FondosIdentificacionPublicaJson { get; set; }

        [Column(TypeName = "decimal(30, 2)")]
        public decimal? FondosSaldo { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? FondosPorcentaje { get; set; }

        // DatosCuentasPorCobrar [ReceivablesData]
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CuentasPorCobrarActual { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CuentasPorCobrarDisponible { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CuentasPorCobrarAnticipado { get; set; }
        public DateTime? CuentasPorCobrarRecoleccionFecha { get; set; }
    }
}
