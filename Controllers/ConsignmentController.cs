using ConsignmentApi.Models;
using ConsignmentApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
namespace ConsignmentApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors("MyCorsImplementationPolicy")]
public class ConsignmentController : ControllerBase
{
    private readonly ConsignmentService _consignmentService;

    public ConsignmentController(ConsignmentService consignmentService) => _consignmentService = consignmentService;

    [HttpGet]
    public async Task<List<ConsignmentData>> Get() => await _consignmentService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ConsignmentData>> Get(string id)
    {
        var consignmentItem = await _consignmentService.GetAsync(id);

        if (consignmentItem is null)
        {
            return NotFound();
        }

        return consignmentItem;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ConsignmentData newItem)
    {
        await _consignmentService.CreateAsync(newItem);

        return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
    }
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, ConsignmentData updatedItem)
    {
        var consignmentItem = await _consignmentService.GetAsync(id);

        if (consignmentItem is null)
        {
            return NotFound();
        }

        updatedItem.Id = consignmentItem.Id;

        await _consignmentService.UpdateAsync(id, updatedItem);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var consignmentItem = await _consignmentService.GetAsync(id);

        if (consignmentItem is null)
        {
            return NotFound();
        }

        await _consignmentService.RemoveAsync(id);

        return NoContent();
    }
}