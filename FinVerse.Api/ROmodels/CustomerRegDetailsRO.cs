using System.ComponentModel.DataAnnotations;

namespace FinVerse.Api.ROmodels
{
    public class CustomerRegDetailsRo
    {
        [Required]
        public int? UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public int? RoleId { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        public int? StateId { get; set; }
        public int? DistrictId { get; set; }

        public DateTime? DOB { get; set; }

        public string? Gender { get; set; }

        public string? MaritalStatus { get; set; }

        public string? Nationality { get; set; }

        public string? KYCStatus { get; set; }

        public int? CreatedBy { get; set; }
    }
}
