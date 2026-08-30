using FinVerse.Infrastructure.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinVerse.Infrastructure.models.ConvertedCurrencyEntity;

namespace FinVerse.Infrastructure.Interface
{
    public interface IExchangeRatesRepository
    {
        Task<int?> InsertExchangeRates( ExchangeRatesEntity ex);
        Task<IList<CurrencyNameEntity>> GetAllCurrencyAsync();
        Task<CurrencyConversionEntity?> CurrencyValueConversion(CurrencyNameEntity currencyName);



    }
}
