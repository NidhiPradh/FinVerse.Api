using FinVerse.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeRatesService _exchangeRatesService;
        public ExchangeController(IExchangeRatesService exchangeRatesService) 
        {
            _exchangeRatesService = exchangeRatesService;
        }

        [HttpGet]
        public async Task<IActionResult> FetchExchangeRates()
        {
            var result = await _exchangeRatesService.FetchExchangeRatesAsnyc();

            return Ok(result);
        }
    }
}
