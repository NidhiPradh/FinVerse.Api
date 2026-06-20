namespace FinVerse.Api.ROmodels
{
    public class NomineeRo
    {       
            public int NomineeId { get; set; }

            public int CustomerId { get; set; }

            public string FullName { get; set; } = string.Empty;

            public string? Relationship { get; set; }

            public string? PhoneNumber { get; set; }
        
    }
}
