using Gol.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gol.WebApi.Infrastructure.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<CarEntity>
{
    public void Configure(EntityTypeBuilder<CarEntity> builder)
    {
        builder.ToTable("Car");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.PassengerCapacity)
            .IsRequired();

        builder.HasOne(x => x.Vehicle)
            .WithOne(x => x.Car)
            .HasForeignKey<CarEntity>(x => x.VehicleId);
    }
}