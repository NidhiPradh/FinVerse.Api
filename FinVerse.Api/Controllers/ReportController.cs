using FinVerse.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinVerse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("UserCustomerReport")]
        public async Task<IActionResult> GetUserCustomerReport()
        {
            var data = await _reportService.GetUserCustomerReportAsync();
            return Ok(data);
        }
    }
}