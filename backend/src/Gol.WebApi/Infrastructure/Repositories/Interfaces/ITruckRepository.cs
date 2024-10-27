using Gol.WebApi.Entities;

namespace Gol.WebApi.Infrastructure.Repositories.Interfaces;

public interface ITruckRepository
{
    Task CreateAsync(TruckEntity truck);

    Task<TruckEntity?> GetByIdAsync(Guid id);
}