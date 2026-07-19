using FinVerse.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Interface
{
    public interface ICustomerService
    {
        Task<bool> InsertCustomerAsync (CustomerDto customer);
        Task<List<CustomerDetailsDto>> GetAllCustomerAsync();
        Task<List<StatesDto>> GetAllStatesAsync();
        Task<List<DistrictDto>> GetDistrictByStateIdAsync(int stateId);
    }
}
