using Gol.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gol.WebApi.Infrastructure.Context;

public class GolContext(DbContextOptions<GolContext> options) : DbContext(options)
{
    public DbSet<VehicleEntity> Vehicle => Set<VehicleEntity>();
    public DbSet<CarEntity> Car => Set<CarEntity>();

    public DbSet<TruckEntity> Truck => Set<TruckEntity>();

    public DbSet<RevisionEntity> Revision => Set<RevisionEntity>();

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<decimal>()
            .HavePrecision(18, 3)
            .HaveColumnType("decimal(18,3)")
            .HaveConversion<decimal>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GolContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }


}