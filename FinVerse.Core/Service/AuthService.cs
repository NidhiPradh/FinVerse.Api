using AutoMapper;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using FinVerse.Infrastructure.Interface;
using FinVerse.Infrastructure.models;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Service
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;
        public AuthService(IMapper mapper, IAuthRepository authRepository, IJwtService jwtService)
        {
            _mapper = mapper;
            _authRepository = authRepository;
            _jwtService = jwtService;
        }
        public async Task<bool> RegisterUser(RegisterRequestDto registerRequest)
        {
            var result = _mapper.Map<RegisterRequestEntity>(registerRequest);
            string firstName = result.FirstName;
            string lastName = result.LastName;
            var username = await GenerateUserName(firstName, lastName);
             
            //var 
            var obj = await _authRepository.RegisterUser(result,username);
            return obj;
        }
        public async Task<String> GenerateUserName(string? firstName, string? lastName )
        {
            string baseUsername = firstName.Trim().ToLower() + char.ToUpper(lastName.Trim()[0]);
                
            int usercount = await _authRepository.CheckUsernameExists(baseUsername);
            if (usercount > 0)
            {
                int counter = usercount;
                // If the username already exists, append a random number to make it unique
                string username= $"{baseUsername}{counter}";
                return username;
            }

            return baseUsername;
        }
        public async Task<string?> LoginUserAsync(LoginRequestDto loginRequestDto)
        {
            var loginRequest = _mapper.Map<LoginRequestEntity>(loginRequestDto);
            var result = await _authRepository.LoginUserAsync(loginRequest);
            var loginResponse = _mapper.Map<LoginResponseDto>(result);
            string token = string.Empty;
            if (loginResponse != null && loginResponse.Email != null)
            {
                // generate token with JwtService — JwtService already includes Email, FullName, RoleId, RoleName claims
                token = _jwtService.GenerateToken(loginResponse);
            }



            return token;
        }

        public async Task<UsersDto?> GetUserByUserId(int? userId)
        {
            var result = await _authRepository.GetUserByUserId(userId);
            return _mapper.Map<UsersDto>(result);
        }

        public async Task<CustomerRegDetailsDto?> GetCustomerByUserId(int? userId)
        {
            var result = await _authRepository.GetCustomerByUserId(userId);
            return _mapper.Map<CustomerRegDetailsDto>(result);
        }
    }
}
