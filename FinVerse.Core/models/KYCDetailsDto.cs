using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.models
{
    public class KYCDetailsDto
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
        public bool? UserImageValid { get; set; }
        public bool? SignatureValid { get; set; }
        public bool? VoterValid { get; set; }
        public bool? AadharValid { get; set; }
        public bool? PanImageValid { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string? Comments { get; set; }



    }
}
