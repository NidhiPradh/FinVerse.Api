namespace FinVerse.Api.ROmodels
{
    public class AddressRo
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
