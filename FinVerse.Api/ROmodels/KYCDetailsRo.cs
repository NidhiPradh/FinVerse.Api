using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinVerse.Api.ROmodels
{
    public class KYCDetailsRo
    {
        public int? KYCId { get; set; }

        public int? UserId { get; set; }

        public string? VerificationStatus { get; set; } = string.Empty;

        public DateTime? SubmittedAt { get; set; }

        //public DateTime? VerifiedAt { get; set; }

        public int? CustomerId { get; set; }
        public IFormFile? UserImage { get; set; }
        public string? ImagePath { get; set; }

        public IFormFile? UserSignature { get; set; }
        public string? SignaturePath { get; set; }

        public IFormFile? UserVoterId { get; set; }
        public string? VoterIdPath { get; set; }

        public IFormFile? UserAadhar { get; set; }
        public string? AadharPath { get; set; }

        public IFormFile? UserPanImage { get; set; }
        public string? PanImagePath { get; set; }
        //Admin update validation
        [JsonPropertyName("userImageValid")]
        public bool? UserImageValid { get; set; }
        [JsonPropertyName("userSignatureValid")]
        public bool? SignatureValid { get; set; }
     
        [JsonPropertyName("userVoterIdValid")]
        public bool? VoterValid { get; set; }
        [JsonPropertyName("userAadharValid")]
        public bool? AadharValid { get; set; }
        [JsonPropertyName("userPanImageValid")]
        public bool? PanImageValid { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [JsonPropertyName("comments")]

        public string? Comments { get; set; }

        

    }
}
