using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.models
{
    public class AddressDto
    {
        public int AddressId { get; set; }

        public int CustomerId { get; set; }

        public string FullAddress { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? PostalCode { get; set; }
    }
}
