namespace API.Belvo.ViewModels
{
    public class TransaccionViewModel
    {
        public string IdTransaccion { get; set; }
        public DateTime RecoleccionFecha { get; set; }
        public DateTime CreadoFecha { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }

        // Comerciante [Merchant]
        public string ComercianteLogo { get; set; }
        public string ComercianteNombre { get; set; }
        public string ComercianteSitioWeb { get; set; } 

        public string Tipo { get; set; }
        public decimal Monto { get; set; }
        public string Estatus { get; set; }
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
        public decimal? TarjetaCreditoFacturaMonto { get; set; }
        public string TarjetaCreditoTotalFacturaAnterior { get; set; }
    }
}
