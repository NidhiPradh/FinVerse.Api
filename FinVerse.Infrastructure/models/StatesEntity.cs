using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.models
{
    public class StatesEntity
    {
        public int? StateId { get; set; }
        public string? StateName { get; set; }
        public int? CountryId { get; set; }
    }
}
