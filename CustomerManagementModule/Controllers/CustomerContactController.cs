using Microsoft.AspNetCore.Mvc;
using CustomerManagementModule.DTOs;
using CustomerManagementModule.Services;

namespace CustomerManagementModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerContactController : ControllerBase
    {
        private readonly CustomerContactService _service;

        public CustomerContactController(CustomerContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerContactDto>>> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerContactDto>> GetById(string id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerContactDto>> Create(CustomerContactDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CustomerContactDto dto)
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
