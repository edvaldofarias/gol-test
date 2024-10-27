using Gol.WebApi.Entities;
using Gol.WebApi.Infrastructure.Context;
using Gol.WebApi.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gol.WebApi.Infrastructure.Repositories;

public class TruckRepository(GolContext context) : ITruckRepository
{
    public async Task CreateAsync(TruckEntity truck)
    {
        await context.Truck.AddAsync(truck);
        await context.SaveChangesAsync();
    }

    public async Task<TruckEntity?> GetByIdAsync(Guid id)
    {
        var truck = await context.Truck.FirstOrDefaultAsync(x => x.Id == id);
        return truck;
    }
}