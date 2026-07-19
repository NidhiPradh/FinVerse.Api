using System.Text.Json.Serialization;

namespace FinVerse.Api.ROmodels
{
    public class DistrictRo
    {
        [JsonPropertyName("districtId")]
        public int? DistrictId { get; set; }
        [JsonPropertyName("districtName")]
        public string? DistrictName { get; set; } = string.Empty;
        [JsonPropertyName("stateId")]
        public int? StateId { get; set; }
        [JsonPropertyName("countryId")]
        public int? CountryId { get; set; }
    }
}
