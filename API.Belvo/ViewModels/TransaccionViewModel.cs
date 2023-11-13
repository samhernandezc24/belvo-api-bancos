namespace API.Belvo.ViewModels
{
    public class TransaccionViewModel
    {
        public string IdTransaccion { get; set; }
        public DateTime RecoleccionFecha { get; set; }
        public DateTime CreadoFecha { get; set; }
        public string TransaccionCategoria { get; set; }
        public string TransaccionSubCategoria { get; set; }

        // Comerciante [Merchant]
        public string ComercianteLogo { get; set; }
        public string ComercianteNombre { get; set; }
        public string ComercianteSitioWeb { get; set; } 

        public string TransaccionTipo { get; set; }
        public decimal TransaccionMonto { get; set; }
        public string TransaccionEstatus { get; set; }
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
        public decimal? TarjetaCreditoFacturaMonto { get; set; }
        public string TarjetaCreditoTotalFacturaAnterior { get; set; }
    }
}
