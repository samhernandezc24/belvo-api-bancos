namespace API.Belvo.ViewModels
{
    public class CuentaViewModel
    {
        public string IdCuenta { get; set; }
        public string IdLink { get; set; }

        // Institucion [Institution]
        public string InstitucionNombre { get; set; }
        public string InstitucionTipo { get; set; }

        public DateTime RecoleccionFecha { get; set; }
        public DateTime CreadoFecha { get; set; }
        public string CuentaNombre { get; set; }
        public string CuentaTipo { get; set; }
        public string CuentaAgencia { get; set; }
        public string CuentaNumero { get; set; }

        // Saldo [Balance]
        public decimal SaldoActual { get; set; }
        public decimal SaldoDisponible { get; set; }

        public string CuentaCategoria { get; set; }
        public string MonedaCodigo { get; set; }
        public string CuentaTipoSaldo { get; set; }
        public string IdProductoBancario { get; set; }
        public DateTime? UltimoAccesoFecha { get; set; }
        public string CuentaIdentificacionInterna { get; set; }
        public string CuentaIdentificacionPublicaNombre { get; set; }
        public string CuentaIdentificacionPublicaValor { get; set; }

        // DatosPrestamo [LoanData]
        // DatosPrestamo [LoanData] => Tarifa [Fees]
        public string PrestamoTarifaTipo { get; set; }
        public string PrestamoTarifaValor { get; set; }

        public string PrestamoTipo { get; set; }
        public decimal? PrestamoPrincipal { get; set; }
        public string PrestamoDiaCorte { get; set; }
        public string PrestamoCorteFecha { get; set; }
        public DateTime? PrestamoRecoleccionFecha { get; set; }

        // DatosPrestamo [LoanData] => TasaInteres [InterestRates]
        public string PrestamoTasaInteresNombre { get; set; }
        public string PrestamoTasaInteresTipo { get; set; }
        public decimal PrestamoTasaInteresValor { get; set; }

        public decimal? PrestamoMontoContrato { get; set; }
        public string PrestamoNumeroContrato { get; set; }
        public string PrestamoContratoInicioFecha { get; set; }
        public string PrestamoContratoFinFecha { get; set; }
        public decimal? PrestamoPagoMensual { get; set; }
        public string PrestamoDiaPago { get; set; }
        public string PrestamoUltimoPagoFecha { get; set; }
        public decimal? PrestamoSaldoPendientePago { get; set; }
        public decimal? PrestamoPrincipalPendientePago { get; set; }
        public string PrestamoNumeroCuotasTotal { get; set; }
        public string PrestamoNumeroCuotasPendientes { get; set; }
        public decimal? PrestamoPagoSinInteres { get; set; }

        // DatosCredito [CreditData]
        public DateTime? CreditoRecoleccionFecha { get; set; }
        public decimal? CreditoLimite { get; set; }
        public string CreditoCorteFecha { get; set; }
        public decimal? CreditoTasaInteres { get; set; }
        public decimal? CreditoPagoMinimo { get; set; }
        public decimal? CreditoPagoMensual { get; set; }
        public string CreditoUltimoPagoFecha { get; set; }
        public string CreditoProximoPagoFecha { get; set; }
        public decimal? CreditoSaldoUltimoPeriodo { get; set; }
        public decimal? CreditoPagoSinInteres { get; set; }        

        // DatosFondo [FundsData]
        public DateTime? FondosRecoleccionFecha { get; set; }
        public string FondosNombre { get; set; }
        public string FondosTipo { get; set; }

        // DatosFondo [FundsData] => IdentificacionPublica [PublicIdentifications]
        public string FondosIdentificacionPublicaNombre { get; set; }
        public string FondosIdentificacionPublicaValor { get; set; }

        public decimal? FondosSaldo { get; set; }
        public decimal? FondosPorcentaje { get; set; }

        // DatosCuentasPorCobrar [ReceivablesData]
        public decimal? CuentasPorCobrarActual { get; set; }
        public decimal? CuentasPorCobrarDisponible { get; set; }
        public decimal? CuentasPorCobrarAnticipado { get; set; }
        public DateTime? CuentasPorCobrarRecoleccionFecha { get; set; }
    }
}
