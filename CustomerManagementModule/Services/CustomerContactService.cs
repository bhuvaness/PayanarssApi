using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagementModule.DTOs;
using CustomerManagementModule.Models;
using CustomerManagementModule.Repositories;

namespace CustomerManagementModule.Services
{
    public class CustomerContactService
    {
        private readonly ICustomerContactRepository _repository;
        private readonly IMapper _mapper;

        public CustomerContactService(ICustomerContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerContactDto>> GetAllAsync()
        {
            var contacts = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerContactDto>>(contacts);
        }

        public async Task<CustomerContactDto?> GetByIdAsync(string id)
        {
            var contact = await _repository.GetByIdAsync(id);
            return contact == null ? null : _mapper.Map<CustomerContactDto>(contact);
        }

        public async Task<CustomerContactDto> AddAsync(CustomerContactDto dto)
        {
            var entity = _mapper.Map<CustomerContact>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<CustomerContactDto>(created);
        }

        public async Task UpdateAsync(CustomerContactDto dto)
        {
            var entity = _mapper.Map<CustomerContact>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string id) => await _repository.DeleteAsync(id);

        public async Task<bool> ExistsAsync(string id) => await _repository.ExistsAsync(id);
    }
}
