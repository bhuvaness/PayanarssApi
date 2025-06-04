using Microsoft.AspNetCore.Mvc;
using CustomerManagementModule.DTOs;
using CustomerManagementModule.Services;

namespace CustomerManagementModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {
            var customers = await _service.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(string id)
        {
            var customer = await _service.GetByIdAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Create(CustomerDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDto>> Update(string id, CustomerDto dto)
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
