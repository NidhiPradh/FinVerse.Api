namespace FinVerse.Api.ROmodels
{
    public class KYCDetailsRo
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
