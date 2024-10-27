using Gol.WebApi.Commands.Revisions;
using Gol.WebApi.Dtos;
using Gol.WebApi.Entities;
using Gol.WebApi.Infrastructure.Repositories.Interfaces;
using Gol.WebApi.Services.Interfaces;

namespace Gol.WebApi.Services;

public class RevisionService(IRevisionRepository revisionRepository) : IRevisionService
{
    public async Task CreateAsync(CreateRevisionCommand command)
    {
        var revision = new RevisionEntity(command.VehicleId, command.Date, command.Value, command.Mileage);
        await revisionRepository.CreateAsync(revision);
    }

    public async Task UpdateAsync(UpdateRevisionCommand command)
    {
        var revision = await revisionRepository.GetByIdAsync(command.Id);
        revision.Update(command.Date, command.Value, command.Mileage);
        await revisionRepository.UpdateAsync(revision);
    }

    public async Task DeleteAsync(Guid id)
    {
        await revisionRepository.DeleteAsync(id);
    }

    public async Task<RevisionDto> GetByIdAsync(Guid id)
    {
        var revision = await revisionRepository.GetByIdAsync(id);
        return new RevisionDto(revision.Id, revision.VehicleId, revision.Value, revision.RevisionDate, revision.Mileage);
    }

    public async Task<IEnumerable<RevisionDto>> GetAllAsync(Guid vehicleId)
    {
        var revisions = await revisionRepository.GetAllAsync(vehicleId);
        return revisions.Select(revision => new RevisionDto(revision.Id, revision.VehicleId, revision.Value, revision.RevisionDate, revision.Mileage));
    }
}