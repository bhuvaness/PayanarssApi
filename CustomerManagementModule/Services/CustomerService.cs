using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagementModule.DTOs;
using CustomerManagementModule.Models;
using CustomerManagementModule.Repositories;

namespace CustomerManagementModule.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto?> GetByIdAsync(string id)
        {
            var customer = await _repository.GetByIdAsync(id);
            return customer == null ? null : _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> AddAsync(CustomerDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<CustomerDto>(created);
        }

        public async Task<CustomerDto> UpdateAsync(CustomerDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            var created = await _repository.UpdateAsync(entity);
            return _mapper.Map<CustomerDto>(created);
        }

        public async Task<bool> DeleteAsync(string id) => await _repository.DeleteAsync(id);

        public async Task<bool> ExistsAsync(string id) => await _repository.ExistsAsync(id);
    }
}
