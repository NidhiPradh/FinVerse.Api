using AutoMapper;
using FinVerse.Api.ROmodels;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinVerse.Api.Controllers
{
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
        public IActionResult InsertCustomerAsync([FromBody] CustomerRO customerRO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customer = _mapper.Map<CustomerDto>(customerRO);
            var result = _customerService.InsertCustomerAsync(customer);
            return Ok("Customer Inserted");
        }
    }

}
