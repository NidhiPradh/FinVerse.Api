using AutoMapper;
using FinVerse.Core.Interface;
using FinVerse.Core.models;
using FinVerse.Infrastructure.Interface;
using FinVerse.Infrastructure.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinVerse.Core.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) 
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDetailsDto>> GetAllCustomerAsync()
        {
            var customers = await _customerRepository.GetAllCustomerAsync();
            var result = _mapper.Map<List<CustomerDetailsDto>>(customers);
            return result;
        }

        public async Task<List<StatesDto>> GetAllStatesAsync()
        {
            var states = await _customerRepository.GetAllStatesAsync();
            var result = _mapper.Map<List<StatesDto>>(states);
            return result;
        }

        public async Task<List<DistrictDto>> GetDistrictByStateIdAsync(int stateId)
        {
            var district = await _customerRepository.GetDistrictByStateIdAsync(stateId);
            var result = _mapper.Map<List<DistrictDto>>(district);
            return result;
        }

        public async Task<bool> InsertCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<CustomerEntity>(customerDto) ;
            var age = customer.DOB.HasValue ? DateTime.Now.Year - customer.DOB.Value.Year : 0;
            if(age >= 18)
            {
                var result = await _customerRepository.InsertCustomerAsync(customer);
                return result;
            }
            throw new Exception("Customer must be at least 18 years old.");
        }
    }
}
