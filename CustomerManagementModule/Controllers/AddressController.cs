using Microsoft.AspNetCore.Mvc;
using CustomerManagementModule.DTOs;
using CustomerManagementModule.Services;

namespace CustomerManagementModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _service;

        public AddressController(AddressService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDto>>> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> GetById(string id)
        {
            var item = await _service.GetByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<AddressDto>> Create(AddressDto dto)
        {
            var created = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, AddressDto dto)
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
