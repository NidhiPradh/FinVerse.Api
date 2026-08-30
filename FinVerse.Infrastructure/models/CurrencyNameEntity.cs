using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.models
{
    public class CurrencyNameEntity
    {
        [JsonPropertyName("currencyCode")]
        public string? CurrencyCode { get; set; }
        [JsonPropertyName("currencyName")]
        public string? CurrencyName { get; set; }
        [JsonPropertyName("exchangeValue")]
        public decimal? ExchangeValue { get; set; }
        [JsonPropertyName("targetCurrencyCode")]
        public string? TargetCurrencyCode { get; set; }
        [JsonPropertyName("targetCurrencyName")]
        public string? targetCurrencyName { get; set; }
        [JsonPropertyName("convertedValue")]
        public decimal? ConvertedValue { get; set; }
    }
}
