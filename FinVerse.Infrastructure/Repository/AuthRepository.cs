using AutoMapper;
using FinVerse.Infrastructure.Data;
using FinVerse.Infrastructure.Interface;
using FinVerse.Infrastructure.models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {      
        private readonly IDBExecutor _dbExecutor;
        public AuthRepository(IDBExecutor dbExecutor)
        {
            _dbExecutor = dbExecutor;
        }

        public async Task<int> CheckUsernameExists(string username)
        {
            const string sql = "SELECT COUNT(userId) FROM users WHERE username LIKE @username + '%'";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@username", username)
            };
            var result = await _dbExecutor.ExecuteScalarInLineQueryAsync<int>(sql, parameters);           
            int count = Convert.ToInt32(result);

            //return Task.FromResult(result > 0);
            return count;
        }

        public async Task<bool> RegisterUser(RegisterRequestEntity registerRequest, string userName)
        {
            try 
            {
                var parameter = new SqlParameter[]
            {
                new SqlParameter("@firstName", registerRequest.FirstName),
                new SqlParameter("@lastName", registerRequest.LastName),
                new SqlParameter("@email", registerRequest.Email),
                new SqlParameter("@passwordHash", registerRequest.Password),
                new SqlParameter("@phoneNumber", registerRequest.PhoneNumber),
                new SqlParameter("@roleId", registerRequest.RoleId),
                new SqlParameter("@isActive",true),
                new SqlParameter("@createdBy", registerRequest.createdBy),
                new SqlParameter("@userName", userName)
                //new SqlParameter("@createdOn", DateTime.UtcNow)
            };
                var result = await _dbExecutor.ExecuteNonQueryAsync("[SP_InsertUser]", parameter);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public async Task<LoginResponseEntity?> LoginUserAsync(LoginRequestEntity loginRequest)
        {
            const string sql = "select email, passwordHash, userName, userId from users where email = @email";

                var parameters = new SqlParameter[]

                {   new SqlParameter("@email", loginRequest.Email),
                    new SqlParameter("@passwordHash", loginRequest.Password)
                };
            var result = await _dbExecutor.ExecuteReaderInLineAsync<LoginResponseEntity>(sql, reader => new LoginResponseEntity
            {
                Email = reader["email"].ToString(),
                Password = reader["passwordHash"].ToString(),
                UserName = reader["userName"].ToString(),
                UserId = reader["userId"] as int? ?? default(int),

            }, parameters);
            var user = result.FirstOrDefault();
            return user;
        }

        public async Task<UsersEntity?> GetUserByUserId(int? userId)
        {
            const string sql = "select * from users where userId = @userId";

            var parameters = new SqlParameter[]

            {   new SqlParameter("@userId", userId),
            };
            var result = await _dbExecutor.ExecuteReaderInLineAsync<UsersEntity>(sql, reader => new UsersEntity
            {
                UserId= reader["userId"] as int? ?? default(int),
                Email = reader["email"].ToString(),
                FirstName = reader["firstName"].ToString(),
                LastName = reader["lastName"].ToString(),
                PhoneNumber = reader["phoneNumber"].ToString(),
                PasswordHash = reader["passwordHash"].ToString(),


            }, parameters);
            var user = result.FirstOrDefault();
            return user;
        }
    }
}
