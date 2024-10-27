using Gol.WebApi.Commands.Cars;
using Gol.WebApi.Dtos;

namespace Gol.WebApi.Services.Interfaces;

public interface ICarService
{
    Task CreateAsync(CreateCarCommand command);

    Task UpdateAsync(UpdateCarCommand command);

    Task<CarDto?> GetByIdAsync(Guid id);
}