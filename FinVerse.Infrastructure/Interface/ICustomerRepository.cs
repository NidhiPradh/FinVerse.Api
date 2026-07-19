using FinVerse.Infrastructure.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.Interface
{
    public interface ICustomerRepository
    {
        Task<bool> InsertCustomerAsync(CustomerEntity customerEntity);
        Task<List<CustomerDetailsEntity>> GetAllCustomerAsync();
        Task<List<StatesEntity>> GetAllStatesAsync();
        Task<List<DistrictEntity>> GetDistrictByStateIdAsync(int stateId);

    }
}
