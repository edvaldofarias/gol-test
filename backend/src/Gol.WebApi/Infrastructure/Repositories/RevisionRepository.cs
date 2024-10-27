using Gol.WebApi.Entities;
using Gol.WebApi.Infrastructure.Context;
using Gol.WebApi.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gol.WebApi.Infrastructure.Repositories;

public class RevisionRepository(GolContext context) : IRevisionRepository
{
    public async Task CreateAsync(RevisionEntity revision)
    {
        await context.Revision.AddAsync(revision);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RevisionEntity revision)
    {
        context.Revision.Update(revision);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var revision = await context.Revision.FirstOrDefaultAsync(x => x.Id == id);
        if (revision is not null)
        {
            context.Revision.Remove(revision);
            await context.SaveChangesAsync();
        }
    }

    public async Task<RevisionEntity?> GetByIdAsync(Guid id)
    {
        var revision = await context.Revision.FirstOrDefaultAsync(x => x.Id == id);
        return revision;
    }

    public async Task<IEnumerable<RevisionEntity>> GetAllAsync(Guid vehicleId)
    {
        var revisions = await context.Revision.Where(x => x.VehicleId == vehicleId).ToListAsync();
        return revisions;
    }
}