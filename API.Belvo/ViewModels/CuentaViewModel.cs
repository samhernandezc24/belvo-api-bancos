namespace API.Belvo.ViewModels
{
    public class CuentaViewModel
    {
        public string IdCuenta { get; set; }
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
        public decimal SaldoActual { get; set; }
        public decimal SaldoDisponible { get; set; }

        public string CuentaMonedaCodigo { get; set; }
        public string CuentaIdentificacionPublicaNombre { get; set; }
        public string CuentaIdentificacionPublicaValor { get; set; }
        public DateTime CuentaLastAccessedFecha { get; set; }

        // DatosCredito [CreditData]
        public decimal CreditoLimite { get; set; }
        public DateTime CreditoCollectedFecha { get; set; }
        public string CreditoCuttingFecha { get; set; }
        public string CreditoNextPaymentFecha { get; set; }
        public decimal CreditoPagoMinimo { get; set; }
        public decimal CreditoSinPagoIntereses { get; set; }
        public decimal CreditoTasaInteres { get; set; }
        public decimal CreditoPagoMensual { get; set; }
        public string CreditoLastPaymentFecha { get; set; }
        public decimal CreditoUltimoPeriodoSaldo { get; set; }

        // DatosPrestamo [LoanData]
        public DateTime PrestamoCollectedFecha { get; set; }
        public decimal PrestamoImporteContrato { get; set; }
        public decimal PrestamoPrincipal { get; set; }
        public string PrestamoTipo { get; set; }
        public string PrestamoDiaPago { get; set; }
        public decimal PrestamoPrincipalPendientePago { get; set; }
        public decimal PrestamoSaldoPendientePago { get; set; }
        public decimal PrestamoPagoMensual { get; set; }

        // DatosPrestamo [LoanData] -> TasaInteres [InterestRates]
        public string PrestamoTasaInteresNombre { get; set; }
        public string PrestamoTasaInteresTipo { get; set; }
        public decimal PrestamoTasaInteresValor { get; set; }

        // DatosPrestamo [LoanData] -> Tarifa [Fees]
        public string PrestamoTarifaTipo { get; set; }
        public decimal PrestamoTarifaValor { get; set; }

        public int PrestamoNumeroPlazosTotal { get; set; }
        public int PrestamoNumeroPlazosPendientes { get; set; }
        public string PrestamoContractStartFecha { get; set; }
        public string PrestamoContractEndFecha { get; set; }
        public string PrestamoNumeroContrato { get; set; }
        public string PrestamoDiaCorte { get; set; }
        public string PrestamoCuttingFecha { get; set; }
        public string PrestamoLastPaymentFecha { get; set; }
        public decimal PrestamoSinPagoIntereses { get; set; }

        // DatosFondo [FundsData]
        public DateTime FondosCollectedFecha { get; set; }
        public string FondosNombre { get; set; }
        public string FondosTipo { get; set; }

        // DatosFondo [FundsData] -> IdentificacionPublica [PublicIdentifications]
        public string FondosIdentificacionPublicaNombre { get; set; }
        public string FondosIdentificacionPublicaValor { get; set; }

        public decimal FondosSaldo { get; set; }
        public decimal FondosPorcentaje { get; set; }

        // DatosCuentasPorCobrar [ReceivablesData]
        public decimal CuentasPorCobrarValorActual { get; set; }
        public decimal CuentasPorCobrarValorDisponible { get; set; }
        public decimal CuentasPorCobrarValorAnticipado { get; set; }
        public DateTime CuentasPorCobrarCollectedFecha { get; set; }

        public string IdProductoBancario { get; set; }
        public string CuentaIdentificacionInterna { get; set; }
    }
}
