using Gol.WebApi.Entities;
using Gol.WebApi.Infrastructure.Context;
using Gol.WebApi.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gol.WebApi.Infrastructure.Repositories;

public class VehicleRepository(GolContext context): IVehicleRepository
{
    public async Task<IEnumerable<VehicleEntity>> GetAllAsync()
    {
        return await context.Vehicle.ToListAsync();
    }

    public async Task CreateAsync(VehicleEntity vehicle)
    {
        await context.Vehicle.AddAsync(vehicle);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(VehicleEntity vehicle)
    {
        context.Vehicle.Update(vehicle);
        await context.SaveChangesAsync();
    }

    public async Task<VehicleEntity?> GetByIdAsync(Guid id)
    {
        return await context.Vehicle
            .Include(x => x.Car)
            .Include(x => x.Truck)
            .FirstOrDefaultAsync(x => x.Id == id);

    }
}