using AutoMapper;
using FinVerse.Api.ROmodels;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinVerse.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase 
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }
        [HttpPost("Insert-Customer")]
        public async Task<IActionResult> InsertCustomerAsync([FromBody] CustomerRO customerRO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Success = false,
                    Message = "Invalid request data."
                });
            }

            var customer = _mapper.Map<CustomerDto>(customerRO);
            var result = await _customerService.InsertCustomerAsync(customer);
            //var result = false; 
            if (result)
            {
                return Ok(new
                {
                    Success = true,
                    Message = "Customer inserted successfully."
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                Success = false,
                Message = "Failed to insert customer."
            });
        }
    }

}
