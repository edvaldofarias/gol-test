using Gol.WebApi.Dtos;
using Gol.WebApi.Infrastructure.Repositories.Interfaces;
using Gol.WebApi.Services.Interfaces;

namespace Gol.WebApi.Services;

public class VehicleService(IVehicleRepository repository) : IVehicleService
{
    public async Task<IEnumerable<VehicleDto>> GetAllAsync()
    {
        var vehicleEntities = await repository.GetAllAsync();
        return vehicleEntities.Select(v => new VehicleDto(v.Id, v.Model, v.Plate, v.Year, v.Color, v.CarId, v.TruckId));
    }
}