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
        public async Task<bool> InsertCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<CustomerEntity>(customerDto) ;
            var result = await _customerRepository.InsertCustomerAsync(customer);
            return result;
        }
    }
}
