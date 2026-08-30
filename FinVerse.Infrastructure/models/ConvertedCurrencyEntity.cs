using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.models
{
    public class ConvertedCurrencyEntity
    {
        public class CurrencyConversionEntity
        {
            public decimal? BaseCurrency { get; set; }
            public decimal? TargetCurrency { get; set; }
        }
    }
}
