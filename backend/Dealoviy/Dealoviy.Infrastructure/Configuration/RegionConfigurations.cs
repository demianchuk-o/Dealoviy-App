using Dealoviy.Domain.Common.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dealoviy.Infrastructure.Configuration;

public class RegionConfigurations : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("Regions");
        
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .IsRequired();
        
        builder.Property(r => r.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.HasMany<City>()
            .WithOne()
            .HasForeignKey(c => c.RegionId);
    }
}