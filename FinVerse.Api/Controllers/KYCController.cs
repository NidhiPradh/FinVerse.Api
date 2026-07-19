using AutoMapper;
using FinVerse.Api.ROmodels;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using FinVerse.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KYCController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IKycService _kycService;

        public KYCController(IMapper mapper, IKycService kycService)
        {
            _kycService = kycService;
            _mapper = mapper;
        }
        [HttpPost("upload-kyc")]
        public async Task<IActionResult> UploadKycDetails([FromForm] KYCDetailsRo kycRo)
        {
            var details = _mapper.Map<KYCDetailsDto>(kycRo);
            var result = await _kycService.UploadKycDetails(details);
            return Ok(result);
        }
        //admin is validating the kyc documents and updating the status of the documents
        [HttpPost("valid-kyc-documents")]
        public async Task<IActionResult> ValidKycDetails([FromBody] KYCDetailsRo kycRo)
        {
            var details = _mapper.Map<KYCDetailsDto>(kycRo);
            var result = await _kycService.UploadKycDetails(details);
            return Ok(result);
        }
        [HttpGet("get-kyc-documents")]
        public async Task<IActionResult> GetKycDocByCustomerId(int customerID)
        {
            var result = await _kycService.GetKycDocByCustomerId(customerID);
            var details = _mapper.Map<KYCDetailsRo>(customerID);

            return Ok(result);
        }
    }
}
