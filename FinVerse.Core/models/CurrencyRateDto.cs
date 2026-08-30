using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.models
{
    public class CurrencyRateDto
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
