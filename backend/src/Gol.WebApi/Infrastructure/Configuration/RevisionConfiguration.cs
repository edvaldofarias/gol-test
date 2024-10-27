using Gol.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gol.WebApi.Infrastructure.Configuration;

public class RevisionConfiguration : IEntityTypeConfiguration<RevisionEntity>
{
    public void Configure(EntityTypeBuilder<RevisionEntity> builder)
    {
        builder.ToTable("Revision");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.RevisionDate)
            .IsRequired();

        builder.Property(x => x.RevisionDate)
            .IsRequired();

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.Revisions)
            .HasForeignKey(x => x.VehicleId);
    }
}