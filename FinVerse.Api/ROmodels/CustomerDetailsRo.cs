namespace FinVerse.Api.ROmodels
{
    public class CustomerDetailsRo
    {

        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? DOB { get; set; }
        public string? Nationality { get; set; }
        public string? MaritalStatus { get; set; }
        public string? AccountNumber { get; set; }
        public int? KYCId { get; set; }
        public string? VerificationStatus { get; set; }  
        //
        public string? ImagePath { get; set; }
        public string? SignaturePath { get; set; }
        public string? VoterIdPath { get; set; }
        public string? AadharPath { get; set; }
        public string? PanImagePath { get; set; }
        public DateTime? SubmittedAt { get; set; }
    }

 }
