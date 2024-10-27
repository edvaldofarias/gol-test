using Gol.WebApi.Commands.Trucks;
using Gol.WebApi.Dtos;

namespace Gol.WebApi.Services.Interfaces;

public interface ITruckService
{
    Task CreateAsync(CreateTruckCommand command);

    Task UpdateAsync(UpdateTruckCommand command);

    Task<TruckDto?> GetByIdAsync(Guid id);
}