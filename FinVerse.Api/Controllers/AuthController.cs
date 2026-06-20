using AutoMapper;
using FinVerse.Api.ROmodels;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace FinVerse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AuthController(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }
        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _mapper.Map<RegisterRequestDto>(registerRequest);
            var obj = await _authService.RegisterUser(result);
            return StatusCode(201, obj);
        }
        [HttpPost("sign-in")]
        public async Task<IActionResult> Login([FromBody] LoginRequestRo loginRequestRo)
        {
            var loginDto = _mapper.Map<LoginRequestDto>(loginRequestRo);
            var token = await _authService.LoginUserAsync(loginDto);
            if (token == null)
                return Unauthorized(new { message = "Invalid username or password" });

            // var ro = //_mapper.Map<LoginResponseRo>(response);
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("user-by-user-id")]
        public async Task<IActionResult> GetUserByUserId([FromQuery] string userId)
        {
            try
            {
                //      var objUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                //      var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                //?? User.FindFirst("userId")?.Value;

                //      if (string.IsNullOrEmpty(objUserId))
                //          return Unauthorized();

                int id = Convert.ToInt32(userId);
                if (id == null || id == 0)
                    return BadRequest("User id is not found.");

                var result = await _authService.GetUserByUserId(id);
                // string jsonResponse = JsonSerializer.Serialize(result); 

                // return Ok(jsonResponse);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");

            }
        }

    }
}
