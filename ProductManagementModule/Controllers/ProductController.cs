using Microsoft.AspNetCore.Mvc;
using ProductManagementModule.DTOs;
using ProductManagementModule.Services;

namespace ProductManagementModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(string id)
        {
            var product = await _service.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(ProductDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> Update(string id, ProductDto dto)
        {
            if (id != dto.Id) return BadRequest();
            if (!await _service.ExistsAsync(id)) return NotFound();
            var created = await _service.UpdateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            if (!await _service.ExistsAsync(id)) return NotFound();
            var deleted = await _service.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
