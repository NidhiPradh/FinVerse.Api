using System.Text.Json.Serialization;

namespace FinVerse.Api.ROmodels
{
    public class StatesRo
    {
        [JsonPropertyName("stateId")]
        public int? StateId { get; set; }
        [JsonPropertyName("stateName")]
        public string? StateName { get; set; }
        [JsonPropertyName("countryId")]
        public int? CountryId { get; set; }
    }
}
