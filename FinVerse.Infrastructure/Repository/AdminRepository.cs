using FinVerse.Infrastructure.Data;
using FinVerse.Infrastructure.Interface;
using FinVerse.Infrastructure.models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IDBExecutor _executor;
        public AdminRepository(IDBExecutor executor)
        {
            _executor = executor;
        }
        public async Task<CustomerDetailsEntity?> GetCustomerDetailsAsync(int CustomerId)
        {
            var parameter = new SqlParameter[]
                {
                    new SqlParameter("@CustomerId", CustomerId)
                };
            var result = await _executor.ExecuteReaderAsync("SP_GetCustomerDetails",
                reader => new CustomerDetailsEntity
                {
                    CustomerId = reader["CustomerId"] as int? ?? default(int),
                    Email = reader["email"].ToString(),
                    FirstName = reader["firstName"].ToString(),
                    LastName = reader["lastName"].ToString(),
                    Nationality = reader["Nationality"].ToString(),
                    MaritalStatus = reader["MaritalStatus"].ToString(),
                    AccountNumber = reader["AccountNumber"].ToString(),
                    KYCId = reader["KYCId"] as int? ?? default(int),
                    VerificationStatus = reader["VerificationStatus"].ToString(),
                    ImagePath = reader["ImagePath"].ToString(),
                    SignaturePath = reader["SignaturePath"].ToString(),
                    VoterIdPath = reader["VoterIdPath"].ToString(),
                    AadharPath = reader["AadharPath"].ToString(),
                    PanImagePath = reader["PanImagePath"].ToString(),
                    SubmittedAt = reader["SubmittedAt"] as DateTime? ?? default(DateTime),
                    DOB = reader["DOB"] as DateTime? ?? default(DateTime),
                    VoterValid = reader["VoterValid"] as bool? ?? default(bool),
                    SignatureValid = reader["SignatureValid"] as bool? ?? default(bool),
                    AadharValid = reader["AadharValid"] as bool? ?? default(bool),
                    UserImageValid = reader["UserImageValid"] as bool? ?? default(bool),
                    PanImageValid = reader["PanImageValid"] as bool? ?? default(bool),
                    Comments = reader["Comments"].ToString()

                }, parameter);

            return result.FirstOrDefault();



        }
    }
}
