using Gol.WebApi.Commands.Revisions;
using Gol.WebApi.Dtos;

namespace Gol.WebApi.Services.Interfaces;

public interface IRevisionService
{
    Task CreateAsync(CreateRevisionCommand command);

    Task UpdateAsync(UpdateRevisionCommand command);

    Task DeleteAsync(Guid id);

    Task<RevisionDto?> GetByIdAsync(Guid id);

    Task<IEnumerable<RevisionDto>> GetAllAsync(Guid vehicleId);
}