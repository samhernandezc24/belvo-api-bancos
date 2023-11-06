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
        public string IdExterno { get; set; }
        public string IdLink { get; set; }

        // Institucion [Institution]
        public string InstitucionNombre { get; set; }
        public string InstitucionTipo { get; set; }
        public string InstitucionCodigo { get; set; }

        public DateTime CuentaCollectedFecha { get; set; }
        public DateTime CuentaCreatedFecha { get; set; }
        public string CuentaCategoria { get; set; }
        public string CuentaSaldoTipo { get; set; }
        public string CuentaTipo { get; set; }
        public string CuentaNombre { get; set; }
        public string CuentaAgencia { get; set; }
        public string CuentaNumero { get; set; }

        // Saldo [Balance]
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? SaldoActual { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? SaldoDisponible { get; set; }

        public string CuentaMonedaCodigo { get; set; }
        public string CuentaIdentificacionPublicaNombre { get; set; }
        public string CuentaIdentificacionPublicaValor { get; set; }
        public DateTime? CuentaLastAccessedFecha { get; set; }

        // DatosCredito [CreditData]
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CreditoLimite { get; set; }
        public DateTime? CreditoCollectedFecha { get; set; }
        public string CreditoCuttingFecha { get; set; }
        public string CreditoNextPaymentFecha { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CreditoPagoMinimo { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CreditoSinPagoIntereses { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CreditoTasaInteres { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CreditoPagoMensual { get; set; }
        public string CreditoLastPaymentFecha { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CreditoUltimoPeriodoSaldo { get; set; }

        // DatosPrestamo [LoanData]
        public DateTime? PrestamoCollectedFecha { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoImporteContrato { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoPrincipal { get; set; }
        public string PrestamoTipo { get; set; }
        public string PrestamoDiaPago { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoPrincipalPendientePago { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoSaldoPendientePago { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoPagoMensual { get; set; }

        // DatosPrestamo [LoanData] -> TasaInteres [InterestRates]
        public string PrestamoTasaInteresJson { get; set; }

        // DatosPrestamo [LoanData] -> Tarifa [Fees]
        public string PrestamoTarifaJson { get; set; }

        public int? PrestamoNumeroPlazosTotal { get; set; }
        public int? PrestamoNumeroPlazosPendientes { get; set; }
        public string PrestamoContractStartFecha { get; set; }
        public string PrestamoContractEndFecha { get; set; }
        public string PrestamoNumeroContrato { get; set; }
        public string PrestamoDiaCorte { get; set; }
        public string PrestamoCuttingFecha { get; set; }
        public string PrestamoLastPaymentFecha { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? PrestamoSinPagoIntereses { get; set; }

        // DatosFondo [FundsData]
        public DateTime? FondosCollectedFecha { get; set; }
        public string FondosNombre { get; set; }
        public string FondosTipo { get; set; }

        // DatosFondo [FundsData] -> IdentificacionPublica [PublicIdentifications]
        public string FondosIdentificacionPublicaJson { get; set; }

        [Column(TypeName = "decimal(30, 2)")]
        public decimal? FondosSaldo { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? FondosPorcentaje { get; set; }

        // DatosCuentasPorCobrar [ReceivablesData]
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CuentasPorCobrarValorActual { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CuentasPorCobrarValorDisponible { get; set; }
        [Column(TypeName = "decimal(30, 2)")]
        public decimal? CuentasPorCobrarValorAnticipado { get; set; }
        public DateTime? CuentasPorCobrarCollectedFecha { get; set; }

        public string IdProductoBancario { get; set; }
        public string CuentaIdentificacionInterna { get; set; }
    }
}
