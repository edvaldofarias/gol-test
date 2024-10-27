using Gol.WebApi.Entities;

namespace Gol.WebApi.Infrastructure.Repositories.Interfaces;

public interface IRevisionRepository
{
    Task CreateAsync(RevisionEntity revision);
    Task UpdateAsync(RevisionEntity revision);
    Task DeleteAsync(Guid id);
    Task<RevisionEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<RevisionEntity>> GetAllAsync(Guid vehicleId);
}