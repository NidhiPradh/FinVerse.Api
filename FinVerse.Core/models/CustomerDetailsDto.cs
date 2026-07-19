using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.models
{
    public class CustomerDetailsDto
    {        
            public int CustomerId { get; set; }
            public DateTime? DOB { get; set; }
            public string? Nationality { get; set; }
            public string? MaritalStatus { get; set; }
            public string? AccountNumber { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public int? KYCId { get; set; }
            public string? VerificationStatus { get; set; }
            public string? ImagePath { get; set; }
            public string? SignaturePath { get; set; }
            public string? VoterIdPath { get; set; }
            public string? AadharPath { get; set; }
            public string? PanImagePath { get; set; }
            public DateTime? SubmittedAt { get; set; }
        //
            public bool? VoterValid { get; set; }
            public bool? SignatureValid { get; set; }
            public bool? AadharValid { get; set; }
            public bool? UserImageValid { get; set; }
            public bool? PanImageValid { get; set; }
            public string? Comments { get; set; }

    }
}
