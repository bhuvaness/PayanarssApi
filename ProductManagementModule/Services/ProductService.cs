using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ProductManagementModule.DTOs;
using ProductManagementModule.Models;
using ProductManagementModule.Repositories;

namespace ProductManagementModule.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetByIdAsync(string id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> AddAsync(ProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<ProductDto>(created);
        }

        public async Task<ProductDto> UpdateAsync(ProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            var created = await _repository.UpdateAsync(entity);
            return _mapper.Map<ProductDto>(created);
        }

        public async Task<bool> DeleteAsync(string id) => await _repository.DeleteAsync(id);

        public async Task<bool> ExistsAsync(string id) => await _repository.ExistsAsync(id);
    }
}
