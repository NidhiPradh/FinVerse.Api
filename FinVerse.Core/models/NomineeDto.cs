using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.models
{
    public class NomineeDto
    {
            public int NomineeId { get; set; }

            public int CustomerId { get; set; }

            public string FullName { get; set; } = string.Empty;

            public string? Relationship { get; set; }

            public string? PhoneNumber { get; set; }
        
    }
}
