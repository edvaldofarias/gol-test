using Gol.WebApi.Commands.Cars;
using Gol.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gol.WebApi.Controllers;

[ApiController]
[Route("[Controller]/[action]")]
public class CarController(ICarService carService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCarCommand command)
    {
        await carService.CreateAsync(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCarCommand command)
    {
        await carService.UpdateAsync(command);
        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var car = await carService.GetByIdAsync(id);
        if(car is null)
        {
            return NotFound();
        }
        return Ok(car);
    }
}