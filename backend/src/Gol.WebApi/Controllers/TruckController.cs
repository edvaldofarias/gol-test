using Gol.WebApi.Commands.Trucks;
using Gol.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gol.WebApi.Controllers;

[ApiController]
[Route("[Controller]/[action]")]
public class TruckController(ITruckService truckService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTruckCommand command)
    {
        await truckService.CreateAsync(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTruckCommand command)
    {
        await truckService.UpdateAsync(command);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var truck = await truckService.GetByIdAsync(id);
        if(truck is null)
        {
            return NotFound();
        }
        return Ok(truck);
    }
}