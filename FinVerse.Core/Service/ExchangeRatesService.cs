using AutoMapper;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using FinVerse.Infrastructure.Interface;
using FinVerse.Infrastructure.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FinVerse.Core.Service
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private readonly IMapper _mapper;
        public readonly ExternalApiService _externalApiService;
        public readonly IExchangeRatesRepository _exchangeRepository;
        public ExchangeRatesService(ExternalApiService externalApiService, IExchangeRatesRepository exchangeRepository,IMapper mapper)
        {
            _externalApiService = externalApiService;
            _exchangeRepository = exchangeRepository;
            _mapper = mapper;
        }
        public async Task<bool?> FetchExchangeRatesAsnyc()
        {
            var result = await _externalApiService.GetExchangeRatesAsync();

        if (result == null)
        { 
            return false; 
        }

        foreach (var rate in result.ConversionRates)
        {
            var exchangeRates = new ExchangeRatesEntity();
            {
                exchangeRates.BaseCurrency = result.BaseCode;
                exchangeRates.TargetCurrency = rate.Key;
                exchangeRates.ExchangeRateValue = rate.Value;
                exchangeRates.LastUpdated = DateTime.Parse(result.LastUpdatedDate);
            }
            var details = _exchangeRepository.InsertExchangeRates(exchangeRates);
        }

        return true;
        }

        public async Task<IList<CurrencyNameDto>> GetAllCurrencyAsync()
        {

            //var result = _mapper.Map<List<CustomerDetailsDto>>(customers);
            var result = await _exchangeRepository.GetAllCurrencyAsync();
            var res = _mapper.Map<IList<CurrencyNameDto>>(result);
            return res;

        }

        public async Task<decimal?> CurrencyValueConversion(CurrencyNameDto? currencyName)
        {
            var obj = _mapper.Map<CurrencyNameEntity>(currencyName);
            var excahngeBaseUsd = await _exchangeRepository.CurrencyValueConversion(obj);
            decimal? baseValue = excahngeBaseUsd.BaseCurrency;
            decimal? targetValue = excahngeBaseUsd.TargetCurrency;
            decimal convertedValue = 0;
            decimal? finalValue = 0;
            if (baseValue != null && targetValue!= null)
            {
                //USD to Local currency conversion
                convertedValue = Convert.ToDecimal(targetValue / baseValue);
                finalValue = convertedValue * currencyName.ExchangeValue;

            }
            //logic to convert the exchange value to target currency
            //if (excahngeBaseUsd != null || excahngeBaseUsd != 0)
            //{
            //    //USD to Local currency conversion
            //    if (currencyName?.TargetCurrencyCode != "USD" && currencyName?.CurrencyCode == "USD") 
            //    {
            //        convertedValue = Convert.ToDecimal(currencyName.ExchangeValue * excahngeBaseUsd);
            //    }
            //    //Local currency to USD conversion
            //    else if (currencyName?.TargetCurrencyCode == "USD" && currencyName?.CurrencyCode != "USD")
            //    {
            //        convertedValue = Convert.ToDecimal(currencyName?.ExchangeValue / excahngeBaseUsd);
            //    }
            //}            
            return finalValue;
        }
        //public decimal CurrencyConversionCalcualtion(string targetCur,string baseCurrncy, )
        //{
        //    return 0;
        //}
    }
}
