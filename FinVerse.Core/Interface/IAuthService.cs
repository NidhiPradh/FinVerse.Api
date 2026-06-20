using FinVerse.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Interface
{
    public interface IAuthService
    {
      Task<bool> RegisterUser(RegisterRequestDto registerRequest);
      Task<string?> LoginUserAsync(LoginRequestDto loginRequestDto);
      Task<String> GenerateUserName(string? firstName, string? lastName);
      Task<UsersDto?> GetUserByUserId(int? userId);



    }
}
