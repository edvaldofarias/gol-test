using Gol.WebApi.Dtos;

namespace Gol.WebApi.Services.Interfaces;

public interface IVehicleService
{
    Task<IEnumerable<VehicleDto>> GetAllAsync();
}