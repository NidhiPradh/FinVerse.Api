using System.ComponentModel.DataAnnotations;

namespace FinVerse.Api.ROmodels
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        public int createdBy { get; set; }
        //public DateTime createdOn { get; set; }
    }
}
