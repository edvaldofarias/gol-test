using Gol.WebApi.Commands.Revisions;
using Gol.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gol.WebApi.Controllers;

[ApiController]
[Route("[Controller]/[action]")]
public class RevisionController(IRevisionService revisionService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRevisionCommand command)
    {
        await revisionService.CreateAsync(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateRevisionCommand command)
    {
        await revisionService.UpdateAsync(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await revisionService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var revision = await revisionService.GetByIdAsync(id);
        return revision is null ? NotFound() : Ok(revision);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(Guid vehicleId)
    {
        var revisions = await revisionService.GetAllAsync(vehicleId);
        return Ok(revisions);
    }
}