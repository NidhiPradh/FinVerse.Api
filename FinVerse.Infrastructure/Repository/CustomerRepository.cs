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
                    new SqlParameter("@ProfileCompletionPercentage", customerEntity.ProfileCompletionPercentage)
                    
                };

            var result =  await _dbExecutor.ExecuteNonQueryAsync("[SP_InsertCustomer]", parameter);
            return result > 0;
        }
    }
}
