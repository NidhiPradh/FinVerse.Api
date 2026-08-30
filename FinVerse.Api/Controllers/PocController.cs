using AutoMapper;
using FinVerse.Api.ROmodels;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PocController : ControllerBase
    {
        private readonly IExchangeRatesService _exchangeRatesService;
        private readonly IMapper _mapper;
        public PocController(IExchangeRatesService exchangeRatesService, IMapper mapper)
        {
            _exchangeRatesService = exchangeRatesService;
            _mapper = mapper;
        }
        [HttpGet("convert-currency")]
        public async Task<IActionResult> GetAllCurrencyAsync()
        {
          var result = await _exchangeRatesService.GetAllCurrencyAsync();           
          return Ok(result);
        }
        [HttpPost("fetch-exchange-rates")]
        public async Task<IActionResult> CurrencyValueConversion([FromBody] CurrencyNameRo currencyName)
        {
            var currencyNameDto = _mapper.Map<CurrencyNameDto>(currencyName);
            var result = await _exchangeRatesService.CurrencyValueConversion(currencyNameDto);
            return Ok(result);
        }
    }
}
