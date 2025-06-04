using Microsoft.AspNetCore.Mvc;
using CustomerManagementModule.DTOs;
using CustomerManagementModule.Services;

namespace CustomerManagementModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerTypeController : ControllerBase
    {
        private readonly CustomerTypeService _service;

        public CustomerTypeController(CustomerTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerTypeDto>>> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerTypeDto>> GetById(string id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerTypeDto>> Create(CustomerTypeDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CustomerTypeDto dto)
        {
            if (id != dto.Id) return BadRequest();
            if (!await _service.ExistsAsync(id)) return NotFound();
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!await _service.ExistsAsync(id)) return NotFound();
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
