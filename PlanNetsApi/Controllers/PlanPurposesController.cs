using Microsoft.AspNetCore.Mvc;
using PlanNetsModule.DMs;
using PlanNetsModule.Services;

namespace PlanNetsModule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanPurposesController : ControllerBase
    {
        private readonly IPlanPurposeService _service;

        public PlanPurposesController(IPlanPurposeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanPurpose>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlanPurpose>> GetById(string id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PlanPurpose entity)
        {
            await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, PlanPurpose entity)
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
