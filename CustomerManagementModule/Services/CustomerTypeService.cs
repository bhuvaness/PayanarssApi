using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagementModule.DTOs;
using CustomerManagementModule.Models;
using CustomerManagementModule.Repositories;

namespace CustomerManagementModule.Services
{
    public class CustomerTypeService
    {
        private readonly ICustomerTypeRepository _repository;
        private readonly IMapper _mapper;

        public CustomerTypeService(ICustomerTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerTypeDto>> GetAllAsync()
        {
            var types = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerTypeDto>>(types);
        }

        public async Task<CustomerTypeDto?> GetByIdAsync(string id)
        {
            var type = await _repository.GetByIdAsync(id);
            return type == null ? null : _mapper.Map<CustomerTypeDto>(type);
        }

        public async Task<CustomerTypeDto> AddAsync(CustomerTypeDto dto)
        {
            var entity = _mapper.Map<CustomerType>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<CustomerTypeDto>(created);
        }

        public async Task UpdateAsync(CustomerTypeDto dto)
        {
            var entity = _mapper.Map<CustomerType>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string id) => await _repository.DeleteAsync(id);

        public async Task<bool> ExistsAsync(string id) => await _repository.ExistsAsync(id);
    }
}
