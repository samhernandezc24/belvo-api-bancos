namespace API.Belvo.ViewModels
{
    public class BelvoTransaccionViewModel
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<TransaccionListResult> results { get; set; }
    }

    public class TransaccionListResult
    {
        public string id { get; set; }
        public CuentaListResult account { get; set; }
        public DateTime collected_at { get; set; }
        public DateTime created_at { get; set; }
        public string category { get; set; }
        public string subcategory { get; set; }
        public Comerciante merchant { get; set; }
        public string type { get; set; }
        public decimal amount { get; set; }
        public string status { get; set; }
        public decimal balance { get; set; }
        public string currency { get; set; }
        public string reference { get; set; }
        public string value_date { get; set; }
        public string description { get; set; }
        public string observations { get; set; }
        public DateTime accounting_date { get; set; }
        public string internal_identification { get; set; }
        public DatosTarjetaCredito credit_card_data { get; set; }
    }

    public class Comerciante
    {
        public string logo { get; set; }
        public string website { get; set; }
        public string merchant_name { get; set; }
    }

    public class DatosTarjetaCredito
    {
        public DateTime collected_at { get; set; }
        public string bill_name { get; set; }
        public string bill_status { get; set; }
        public decimal bill_amount { get; set; }
        public string previous_bill_total { get; set; }
    }
}
