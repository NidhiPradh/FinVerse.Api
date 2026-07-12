using FinVerse.Infrastructure.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Infrastructure.Interface
{
    public interface IAdminRepository
    {
        Task<CustomerDetailsEntity?> GetCustomerDetailsAsync(int CustomerId);
    }
}
