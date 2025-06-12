using Microsoft.AspNetCore.Mvc;
using PlanNetsModule.DTOs;
using PlanNetsModule.Services;

namespace PlanNetsModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanStatusesControler : ControllerBase
    {
        private readonly IPlanStatusService _service;

        public PlanStatusesControler(IPlanStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanStatusDto>>> GetAll(string? search = null, int page = 1, int pageSize = 10)
        {
            var items = await _service.GetAllAsync(search, page, pageSize);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlanStatusDto>> GetById(string id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PlanStatusDto entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, PlanStatusDto entity)
        {
            if (id != entity.Id) return BadRequest();
            await _service.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
