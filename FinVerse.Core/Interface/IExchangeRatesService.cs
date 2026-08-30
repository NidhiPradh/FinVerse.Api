using FinVerse.Core.models;
using FinVerse.Infrastructure.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Interface
{
    public interface IExchangeRatesService
    {
        Task<bool?> FetchExchangeRatesAsnyc();
        Task<IList<CurrencyNameDto>> GetAllCurrencyAsync();
        Task<decimal?> CurrencyValueConversion(CurrencyNameDto currencyCode);

    }
}
