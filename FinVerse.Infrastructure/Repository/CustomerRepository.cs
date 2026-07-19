using FinVerse.Infrastructure.Data;
using FinVerse.Infrastructure.Interface;
using FinVerse.Infrastructure.models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDBExecutor _dbExecutor;
        public CustomerRepository(IDBExecutor dbExecutor) 
        {
            _dbExecutor = dbExecutor;
        }

        public async Task<List<CustomerDetailsEntity>> GetAllCustomerAsync()
        {

            var result = await _dbExecutor.ExecuteReaderAsync("SP_GetAllCustomerDetails",
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

                }, null);

            return result;
        }

        public async Task<List<StatesEntity>> GetAllStatesAsync()
        {
            var result = await _dbExecutor.ExecuteReaderAsync("sp_GetAllStates",
                            reader => new StatesEntity
                            {
                                StateId = reader["StateId"] as int? ?? default(int),
                                StateName = reader["StateName"].ToString(),
                                CountryId = reader["CountryId"] as int? ?? default(int),
                                

                            }, null);
            return result;
        }

        public async Task<List<DistrictEntity>> GetDistrictByStateIdAsync(int stateId)
        {
            var parameter = new SqlParameter[]
            {
                new SqlParameter("@StateId", stateId)
            };
            var result = await _dbExecutor.ExecuteReaderAsync("SP_GetDistrictsByStateId",
                reader => new DistrictEntity
                {
                    DistrictId = reader["DistrictId"] as int? ?? default(int),
                    DistrictName = reader["DistrictName"].ToString(),
                    StateId = reader["StateId"] as int? ?? default(int),
                    CountryId = reader["CountryId"] as int? ?? default(int),
                }, parameter);
            return result;
        }

        

        public async Task<bool> InsertCustomerAsync(CustomerEntity customerEntity)
        {
            var parameter = new SqlParameter[]
                {
                    new SqlParameter("@UserId", customerEntity.UserId),
                    new SqlParameter("@DOB", customerEntity.DOB),
                    new SqlParameter("@Gender", customerEntity.Gender),
                    new SqlParameter("@MaritalStatus", customerEntity.MaritalStatus),
                    new SqlParameter("@Nationality", customerEntity.Nationality),
                    new SqlParameter("@KYCStatus", customerEntity.KYCStatus),
                    new SqlParameter("@StateId", customerEntity.StateId),
                    new SqlParameter("@DistrictId", customerEntity.DistrictId),
                    new SqlParameter("@ProfileCompletionPercentage", customerEntity.ProfileCompletionPercentage)
                    
                };

            var result =  await _dbExecutor.ExecuteNonQueryAsync("[SP_InsertCustomer]", parameter);
            return result > 0;
        }
    }
}
