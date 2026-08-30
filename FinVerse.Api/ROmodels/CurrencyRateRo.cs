using System.Text.Json.Serialization;

namespace FinVerse.Api.ROmodels
{
    public class CurrencyRateRo
    {
        [JsonPropertyName("currencyCode")]
        public string? CurrencyCode { get; set; }
        [JsonPropertyName("currencyName")]
        public string? CurrencyName { get; set; }
    }
}
