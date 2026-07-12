using FinVerse.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Interface
{
    public interface IAdminService
    {
        Task<CustomerDetailsDto?> GetCustomerDetailsAsync(int CustomerId);

    }
}
