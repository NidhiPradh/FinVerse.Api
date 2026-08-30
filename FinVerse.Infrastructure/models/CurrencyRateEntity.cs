using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.models
{
    public class CurrencyRateEntity
    {
        public string CurrencyCode { get; set; } //INR
        public string CurrencyName { get; set; } //Indian Rupee
        public decimal ExchangeRate { get; set; }//450
    }
}
