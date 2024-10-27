using Gol.WebApi.Entities;
using Gol.WebApi.Infrastructure.Context;
using Gol.WebApi.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gol.WebApi.Infrastructure.Repositories;

public class CarRepository(GolContext context) : ICarRepository
{
    public async Task CreateAsync(CarEntity car)
    {
        await context.Car.AddAsync(car);
        await context.SaveChangesAsync();
    }

    public async Task<CarEntity?> GetByIdAsync(Guid id)
    {
        var car =  await context.Car.FirstOrDefaultAsync(x => x.Id == id);
        return car;
    }
}