using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.models
{
    public class DistrictDto
    {
        public int? DistrictId { get; set; }

        public string? DistrictName { get; set; } = string.Empty;

        public int? StateId { get; set; }

        public int? CountryId { get; set; }
    }
}
