namespace API.Belvo.ViewModels
{
    public class TransaccionViewModel
    {
        public string IdTransaccion { get; set; }
        public string TransaccionIdentificacionInterna { get; set; }
        public DateTime RecoleccionFecha { get; set; }
        public string RecoleccionFechaNatural => RecoleccionFecha.ToString("dd/MM/yyyy hh:mm tt");
        public DateTime CreadoFecha { get; set; }
        public string CreadoFechaNatural => CreadoFecha.ToString("dd/MM/yyyy hh:mm tt");
        public string TransaccionValorFecha { get; set; }
        public DateTime TransaccionContableFecha { get; set; }
        public decimal TransaccionMonto { get; set; }
        public string TransaccionMontoNatural => TransaccionMonto.ToString("C");
        public decimal TransaccionSaldo { get; set; }
        public string TransaccionSaldoNatural => TransaccionSaldo.ToString("C");
        public string MonedaCodigo { get; set; }
        public string TransaccionDescripcion { get; set; }
        public string TransaccionObservaciones { get; set; }

        // Comerciante [Merchant]
        public string ComercianteLogo { get; set; }
        public string ComercianteSitioWeb { get; set; }
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
        public decimal? TarjetaCreditoFacturaMonto { get; set; }
        public string TarjetaCreditoTotalFacturaAnterior { get; set; }

        // AspNetUser [AspNetUser]
        public string IdCreatedUser { get; set; }
        public string CreatedUserName { get; set; }
        public DateTime CreatedFecha { get; set; }
        public string CreatedFechaNatural => CreatedFecha.ToString("dd/MM/yyyy hh:mm tt");

        public string IdUpdatedUser { get; set; }
        public string UpdatedUserName { get; set; }
        public DateTime UpdatedFecha { get; set; }
        public string UpdatedFechaNatural => UpdatedFecha.ToString("dd/MM/yyyy hh:mm tt");
    }
}
