using AutoMapper;
using FinVerse.Api.ROmodels;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using FinVerse.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinVerse.Api.Controllers
{
    //[Authorize]
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
        [HttpPost("insert-customer")]
        public async Task<IActionResult> InsertCustomerAsync([FromBody] CustomerRo customerRO)
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
        [AllowAnonymous]
        [HttpGet("get-all-customers")]
        public async Task<IActionResult> GetAllCustomerAsync()
        {
            try
            {
                var customers = await _customerService.GetAllCustomerAsync();
                var result = _mapper.Map<List<CustomerDetailsRo>>(customers);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("get-all-states")]
        public async Task<IActionResult> GetAllStatesAsync()
        {
            try
            {
                var states = await _customerService.GetAllStatesAsync();
                var result = _mapper.Map<List<StatesRo>>(states);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("get-districts-by-state")]
        public async Task<IActionResult> GetDisctrictByStateIdAsync([FromQuery] int stateId)
        {
            try
            {
                var districts = await _customerService.GetDistrictByStateIdAsync(stateId);
                var result = _mapper.Map<List<DistrictRo>>(districts);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return (StatusCode(500, $"Internal server error: {ex.Message}"));
            }
        }

    }

}
