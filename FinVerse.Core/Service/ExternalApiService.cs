using FinVerse.Core.Extensions;
using FinVerse.Core.models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Service
{
    public class ExternalApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public ExternalApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<ExchangeRatesDto> GetExchangeRatesAsync()
        {
            // Implement the logic to call the external API and retrieve exchange rates
            // For example, you can use HttpClient to make an HTTP request to the API endpoint
            // and deserialize the response into an ExchangeRatesDto object.
            var section = _configuration.GetSection("ExternalApi");
            var endpoint = section.GetValue<string>("BaseUrl");   
            return await _httpClient.GetApiDataAsync<ExchangeRatesDto>(endpoint);
        }

    }
}
