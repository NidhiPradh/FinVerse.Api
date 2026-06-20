using System.ComponentModel.DataAnnotations;

namespace FinVerse.Api.ROmodels
{
    public class CustomerRO
    {
        [Required]
        public int? UserId { get; set; }

        public DateTime? DOB { get; set; }

        public string? Gender { get; set; }

        public string? MaritalStatus { get; set; }

        public string? Nationality { get; set; }

        public string? KYCStatus { get; set; }

        public decimal? ProfileCompletionPercentage { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
