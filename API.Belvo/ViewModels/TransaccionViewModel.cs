namespace API.Belvo.ViewModels
{
    public class TransaccionViewModel
    {
        public string IdTransaccion { get; set; }
        public DateTime AccountingFecha { get; set; }
        public decimal Monto { get; set; }
        public decimal Saldo { get; set; }
        public string Categoria { get; set; }
        public DateTime CollectedFecha { get; set; }
        public DateTime CreatedFecha { get; set; }
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
        public string ComercianteLogo { get; set; }
        public string ComercianteNombre { get; set; }
        public string ComercianteSitioWeb { get; set; }

        // TarjetaCredito [CreditCard]
        public string TarjetaCreditoCuentaNombre { get; set; }
        public string TarjetaCreditoTotalCuentaAnterior { get; set; }
        public DateTime? TarjetaCreditoCollectedFecha { get; set; }
    }
}
