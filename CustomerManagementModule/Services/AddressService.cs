using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomerManagementModule.DTOs;
using CustomerManagementModule.Models;
using CustomerManagementModule.Repositories;

namespace CustomerManagementModule.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddressDto>> GetAllAsync()
        {
            var addresses = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AddressDto>>(addresses);
        }

        public async Task<AddressDto?> GetByIdAsync(string id)
        {
            var address = await _repository.GetByIdAsync(id);
            return address == null ? null : _mapper.Map<AddressDto>(address);
        }

        public async Task<AddressDto> AddAsync(AddressDto dto)
        {
            var entity = _mapper.Map<Address>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<AddressDto>(created);
        }

        public async Task UpdateAsync(AddressDto dto)
        {
            var entity = _mapper.Map<Address>(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string id) => await _repository.DeleteAsync(id);

        public async Task<bool> ExistsAsync(string id) => await _repository.ExistsAsync(id);
    }
}
