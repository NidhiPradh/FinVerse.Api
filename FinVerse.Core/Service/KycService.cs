using AutoMapper;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using FinVerse.Infrastructure.Interface;
using FinVerse.Infrastructure.models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Service
{
    public class KycService : IKycService
    {
        private readonly IMapper _mapper;
        private readonly IKYCRepository _kycRepository;
        private readonly IWebHostEnvironment _environment;
        public KycService(IMapper mapper, IKYCRepository kycRepository, IWebHostEnvironment environment) 
        {
            _kycRepository = kycRepository;
            _mapper = mapper;
            _environment = environment;
        }
        public Task<bool> UploadKycDetails(KYCDetailsDto kycdto)
        {
            var details = _mapper.Map<KYCDetailsEntity>(kycdto);
            details.ImagePath = SaveFile(details.UserImage!);
            details.VoterIdPath = SaveFile(details.UserVoterId!);
            details.AadharPath = SaveFile(details.UserAadhar!);
            details.PanImagePath = SaveFile(details.UserPanImage!);
            details.SignaturePath = SaveFile(details.UserSignature!);
            var result = _kycRepository.UploadKycDetails(details);
            return result;
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
    }
}
