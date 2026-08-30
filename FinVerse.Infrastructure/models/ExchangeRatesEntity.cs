using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.models
{
    public class ExchangeRatesEntity
    {
        [JsonPropertyName("result")]
        public string TargetCurrency { get; set; }

        [JsonPropertyName("base_code")]
        public string BaseCurrency { get; set; }

        [JsonPropertyName("conversion_rates")]
        public decimal ExchangeRateValue { get; set; }

        [JsonPropertyName("time_last_update_utc")]
        public DateTime LastUpdated { get; set; }
    }
}
