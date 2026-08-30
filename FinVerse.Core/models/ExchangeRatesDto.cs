using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinVerse.Core.models
{
    public class ExchangeRatesDto
    {
        [JsonPropertyName("result")]
        public string Result { get; set; }

        [JsonPropertyName("base_code")]
        public string BaseCode { get; set; }

        [JsonPropertyName("conversion_rates")]
        public Dictionary<string, decimal> ConversionRates { get; set; }

        [JsonPropertyName("time_last_update_utc")]
        public String LastUpdatedDate { get; set; }
    }
}
