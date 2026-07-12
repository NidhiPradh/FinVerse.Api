using AutoMapper;
using FinVerse.Api.ROmodels;
using FinVerse.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }
        [HttpGet("Get-Customer-Details")]
        public async Task<IActionResult> GetCustomerDetailsAsync([FromQuery] int CustomerId) 
        {
            var details = await _adminService.GetCustomerDetailsAsync(CustomerId);
            var result = _mapper.Map<CustomerDetailsRo>(details);
            return Ok(result);


        }
        [HttpGet("download-image")]
        public IActionResult DownloadImage([FromQuery] string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return BadRequest("Image path is required.");

            if (!System.IO.File.Exists(path))
                return NotFound("Image not found.");

            var extension = Path.GetExtension(path).ToLowerInvariant();

            var contentType = extension switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                _ => "application/octet-stream"
            };

            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            return File(stream, contentType, enableRangeProcessing: true);
     
        }

        
    }
}
