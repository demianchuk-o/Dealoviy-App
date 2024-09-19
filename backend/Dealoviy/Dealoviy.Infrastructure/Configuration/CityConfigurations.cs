using Dealoviy.Domain.Common.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dealoviy.Infrastructure.Configuration;

public class CityConfigurations : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");
        
        builder.HasKey(c => c.Id);
            
        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .IsRequired();
            
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
            
        builder.Property(c => c.RegionId)
            .IsRequired();
    }
}