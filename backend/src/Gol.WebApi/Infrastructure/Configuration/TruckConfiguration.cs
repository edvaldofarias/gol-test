using Gol.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gol.WebApi.Infrastructure.Configuration;

public class TruckConfiguration : IEntityTypeConfiguration<TruckEntity>
{
    public void Configure(EntityTypeBuilder<TruckEntity> builder)
    {
        builder.ToTable("Truck");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.LoadCapacity)
            .IsRequired();

        builder.HasOne(x => x.Vehicle)
            .WithOne(x => x.Truck)
            .HasForeignKey<TruckEntity>(x => x.VehicleId);
    }
}