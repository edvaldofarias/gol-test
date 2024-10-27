using Gol.WebApi.Entities;

namespace Gol.WebApi.Infrastructure.Repositories.Interfaces;

public interface IVehicleRepository
{
    Task<IEnumerable<VehicleEntity>> GetAllAsync();

    Task CreateAsync(VehicleEntity vehicle);

    Task UpdateAsync(VehicleEntity vehicle);

    Task<VehicleEntity?> GetByIdAsync(Guid id);
}