using Gol.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gol.WebApi.Infrastructure.Configuration;

public class VehicleConfiguration : IEntityTypeConfiguration<VehicleEntity>
{
    public void Configure(EntityTypeBuilder<VehicleEntity> builder)
    {
        builder.ToTable("Vehicle");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Plate)
            .HasMaxLength(7)
            .IsRequired();

        builder.Property(x => x.Model)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Color)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Year)
            .IsRequired();

        builder.HasOne(x => x.Car)
            .WithOne(x => x.Vehicle)
            .HasForeignKey<CarEntity>(x => x.VehicleId);

        builder.HasOne(x => x.Truck)
            .WithOne(x => x.Vehicle)
            .HasForeignKey<TruckEntity>(x => x.VehicleId);
    }
}