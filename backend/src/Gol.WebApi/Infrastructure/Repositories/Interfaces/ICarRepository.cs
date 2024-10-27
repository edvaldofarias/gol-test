using Gol.WebApi.Entities;

namespace Gol.WebApi.Infrastructure.Repositories.Interfaces;

public interface ICarRepository
{
    Task CreateAsync(CarEntity car);

    Task<CarEntity?> GetByIdAsync(Guid id);
}