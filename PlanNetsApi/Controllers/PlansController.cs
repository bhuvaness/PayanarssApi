using Microsoft.AspNetCore.Mvc;
using PlanNetsModule.DTOs;
using PlanNetsModule.Services;

[ApiController]
[Route("api/[controller]")]
public class PlansController : ControllerBase
{
    private readonly IPlanService _service;

    public PlansController(IPlanService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlanDto>>> GetAll(string? search = null, int page = 1, int pageSize = 10)
    {
        var items = await _service.GetAllAsync(search, page, pageSize);
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlanDto>> GetById(string id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> Create(PlanDto entity)
    {
        await _service.AddAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(string id, PlanDto entity)
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
