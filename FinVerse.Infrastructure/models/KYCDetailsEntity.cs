using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.models
{
    public class KYCDetailsEntity
    {
            public int KYCId { get; set; }

            public int UserId { get; set; }

            public string DocumentType { get; set; } = string.Empty;

            public string DocumentPath { get; set; } = string.Empty;

            public string VerificationStatus { get; set; } = "Pending";

            public DateTime SubmittedAt { get; set; }

            public DateTime? VerifiedAt { get; set; }
        
    }
}
