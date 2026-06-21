using FinVerse.Core.Interface;
using FinVerse.Core.models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Service
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(LoginResponseDto loginResponseDto)
        {
            var claims = new[]//claim array
            {
                 new Claim(JwtRegisteredClaimNames.Email, loginResponseDto.Email ?? ""),
                //new Claim("FullName", loginResponseDto.FullName ?? ""),
                new Claim("RoleId", loginResponseDto?.RoleId?.ToString()!),
                //new Claim("RoleName", loginResponseDto.RoleName ?? ""),
                //new Claim("UserId", loginResponseDto.UserId.ToString()),
                new Claim("UserName", loginResponseDto.UserName ?? ""),
                //new Claim(ClaimTypes.Name, loginResponseDto.UserName),
                //new Claim(ClaimTypes.Email, loginResponseDto.Email),
                new Claim("userId", loginResponseDto?.UserId?.ToString()!),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
