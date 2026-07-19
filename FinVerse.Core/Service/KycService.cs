using AutoMapper;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using FinVerse.Infrastructure.Interface;
using FinVerse.Infrastructure.models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Service
{
    public class KycService : IKycService
    {
        private readonly IMapper _mapper;
        private readonly IKYCRepository _kycRepository;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;
        private readonly IAdminRepository _adminRepository;
        public KycService(IMapper mapper, IKYCRepository kycRepository, IWebHostEnvironment environment, IConfiguration configuration,IAdminRepository adminRepository) 
        {
            _kycRepository = kycRepository;
            _mapper = mapper;
            _environment = environment;
            _adminRepository = adminRepository;
            _configuration = configuration;
        }

        public Task<List<KYCDetailsDto>> GetKycDocByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UploadKycDetails(KYCDetailsDto kycdto)
        {
            var details = _mapper.Map<KYCDetailsEntity>(kycdto);
            int customerId = (int)details.CustomerId;
            var customerDetails = await _adminRepository.GetCustomerDetailsAsync(customerId);
            var name = $"{customerDetails.FirstName} {customerDetails.LastName}";            


            //TO do 1 : check all valid then create a flag variable 
           bool verified = false;
            if (kycdto.UserImageValid == true && kycdto.SignatureValid == true && kycdto.VoterValid == true &&
                kycdto.AadharValid == true && kycdto.PanImageValid == true)
            {
                details.VerificationStatus = "verified";
                verified = true;
            }
            else
            {
                details.VerificationStatus = "pending";
                details.ImagePath = SaveFile(details.UserImage!);
                details.VoterIdPath = SaveFile(details.UserVoterId!);
                details.AadharPath = SaveFile(details.UserAadhar!);
                details.PanImagePath = SaveFile(details.UserPanImage!);
                details.SignaturePath = SaveFile(details.UserSignature!);
            }
            var result = _kycRepository.UploadKycDetails(details, details.VerificationStatus);
            
            //TO do 2: Create  a method. if result is true and to do 1 variable true then send email to customer email id.
            if(verified == true && result.Result == true && customerDetails.Email!= null)
            {
               var _ = SendKycApprovalEmail(customerDetails.Email, name);
                //send email to customer email id
            }

            return result.Result;
        }

        private string SaveFile(IFormFile formFile)
        {
            try
            {
                if(formFile == null || formFile.Length == 0)
                    return string.Empty;
                string uploadsFolder = Path.Combine(_environment.ContentRootPath, "UploadedFiles");

                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyToAsync(stream);
                }

                // Save relative path in DB
                string relativePath = $"UploadedFiles/{uniqueFileName}";
                return relativePath;
            }
            catch (Exception ex) { 
                return string.Empty;
            }
            
        }

        private async Task<String> SendKycApprovalEmail(string email, string name)
        {
            string senderEmail = _configuration["SmtpSettings:Email"]!;
            string appPassword = _configuration["SmtpSettings:AppPassword"]!;
            var message = new MailMessage();
            message.From = new MailAddress("Finverse@gmail.com");
            message.To.Add(email);
            message.Subject = "KYC Verification Completed";
            message.Body = $@"
            Dear {name},

            Congratulations!

            Your KYC verification has been successfully completed and approved.

            You can now enjoy all the banking services available on your account.

            Thank you for choosing Finverse Bank.

            Regards,
            Finverse Bank
            ";

            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
            smtp.EnableSsl = true;

            await smtp.SendMailAsync(message);
            return string.Empty;
                        // Implement email sending logic here
            // You can use an email service like SMTP, SendGrid, etc.
            // Example:
            // var subject = "KYC Approval Notification";
            // var body = $"Dear {firstName},\n\nYour KYC documents have been successfully verified.\n\nThank you.";
            // EmailService.SendEmail(email, subject, body);
        }
    }
}
