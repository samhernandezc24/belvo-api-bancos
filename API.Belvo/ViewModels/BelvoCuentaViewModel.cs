namespace API.Belvo.ViewModels
{
    public class BelvoCuentaViewModel
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<CuentaListResult> results { get; set; }
    }

    public class CuentaListResult
    {
        public string id { get; set; }
        public string link { get; set; }
        public Institucion institution { get; set; }
        public string institution_name => institution != null ? institution.name.Split("_").GetValue(0).ToString() : "";
        public string institution_code => institution != null ? institution.name : "";
        public string institution_type => institution != null ? institution.type : "";
        public DateTime created_at { get; set; }
        public string created_at_natural => created_at.ToString("dd/MM/yyyy hh:mm tt");
        public string name { get; set; }
        public string type { get; set; }
        public string agency { get; set; }
        public string number { get; set; }
        public Saldo balance { get; set; }
        public string category { get; set; }
        public string currency { get; set; }
        public DatosPrestamo loan_data { get; set; }
        public DatosCredito credit_data { get; set; }
        public DatosFondo funds_data { get; set; }
        public string balance_type { get; set; }
        public DateTime collected_at { get; set; }
        public DatosCuentasPorCobrar receivables_data { get; set; }
        public string bank_product_id { get; set; }
        public DateTime? last_accessed_at { get; set; }
        public string last_accessed_at_natural => last_accessed_at.HasValue ? last_accessed_at.Value.ToString("dd/MM/yyyy hh:mm tt") : null;
        public string internal_identification { get; set; }
        public string public_identification_name { get; set; }
        public string public_identification_value { get; set; }
    }

    public class Institucion
    {
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Saldo
    {
        public decimal? current { get; set; }
        public decimal? available { get; set; }
    }

    public class DatosPrestamo
    {
        public DateTime collected_at { get; set; }
        public decimal? contract_amount { get; set; }
        public decimal? principal { get; set; }
        public string loan_type { get; set; }
        public string payment_day { get; set; }
        public decimal? outstanding_principal { get; set; }
        public decimal? outstanding_balance { get; set; }
        public decimal? monthly_payment { get; set; }
        public List<TasaInteres> interest_rates { get; set; }
        public List<Tarifa> fees { get; set; }
        public string number_of_installments_total { get; set; }
        public string number_of_installments_outstanding { get; set; }
        public string contract_start_date { get; set; }
        public string contract_end_date { get; set; }
        public string contract_number { get; set; }
        public string cutting_day { get; set; }
        public string cutting_date { get; set; }
    }

    public class DatosCredito
    {
        public DateTime collected_at { get; set; }
        public decimal? credit_limit { get; set; }
        public string cutting_date { get; set; }
        public decimal? interest_rate { get; set; }
        public decimal? minimum_payment { get; set; }
        public decimal? monthly_payment { get; set; }
        public string last_payment_date { get; set; }
        public string next_payment_date { get; set; }
        public decimal? last_period_balance { get; set; }
        public decimal? no_interest_payment { get; set; }
    }

    public class DatosFondo
    {
        public DateTime collected_at { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public List<IdentificacionPublica> public_identifications { get; set; }
        public decimal? balance { get; set; }
        public decimal? percentage { get; set; }
    }

    public class DatosCuentasPorCobrar
    {
        public decimal? current { get; set; }
        public decimal? available { get; set; }
        public decimal? anticipated { get; set; }
        public DateTime collected_at { get; set; }
    }

    public class TasaInteres
    {
        public string name { get; set; }
        public string type { get; set; }
        public decimal? value { get; set; }
    }

    public class Tarifa
    {
        public string type { get; set; }
        public decimal value { get; set; }
    }

    public class IdentificacionPublica
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}
