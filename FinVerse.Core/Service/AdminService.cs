using AutoMapper;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using FinVerse.Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        public AdminService(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDetailsDto?> GetCustomerDetailsAsync(int CustomerID)
        {
            var details = await _adminRepository.GetCustomerDetailsAsync(CustomerID);
            var result = _mapper.Map<CustomerDetailsDto>(details);
          
            return result;
        }

    }
}
