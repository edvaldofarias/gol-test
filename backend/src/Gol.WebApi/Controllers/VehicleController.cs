using Gol.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gol.WebApi.Controllers;

[ApiController]
[Route("[Controller]/[action]")]
public class VehicleController(IVehicleService vehicleService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await vehicleService.GetAllAsync();
        return Ok(vehicles);
    }
}