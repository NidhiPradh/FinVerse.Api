using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.models
{
    public class CustomerDto
    {
        public int UserId { get; set; }

        public DateTime? DOB { get; set; }

        public string? Gender { get; set; }

        public string? MaritalStatus { get; set; }

        public string? Nationality { get; set; }

        public string? KYCStatus { get; set; }

        public decimal? ProfileCompletionPercentage { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
