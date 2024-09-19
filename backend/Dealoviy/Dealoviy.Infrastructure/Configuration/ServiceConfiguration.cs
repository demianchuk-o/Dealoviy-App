using Dealoviy.Domain.Common.Location;
using Dealoviy.Domain.ContractorProfiles;
using Dealoviy.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dealoviy.Infrastructure.Configuration;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("Services");
        
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .ValueGeneratedNever();

        builder.HasOne<ContractorProfile>()
            .WithMany()
            .HasForeignKey(s => s.ContractorId);
        builder.Property(s => s.ContractorId)
            .IsRequired();
        
        builder.HasOne<City>()
            .WithMany()
            .HasForeignKey(s => s.CityId);
        builder.Property(s => s.CityId)
            .IsRequired();

        builder.Property(s => s.Name)
            .HasMaxLength(100);
        builder.Property(s => s.Name)
            .IsRequired();
        
        builder.Property(s => s.Description)
            .HasMaxLength(255);
        builder.Property(s => s.Description)
            .IsRequired();
        
        builder.OwnsOne(s => s.PriceRange, b =>
        {
            b.Property(pr => pr.Lower)
                .HasColumnName("LowerPriceBound");
            
            b.Property(pr => pr.Upper)
                .HasColumnName("UpperPriceBound");
        });
        
        builder.OwnsOne(s => s.AverageRating, b =>
        {
            b.Property(ar => ar.Value)
                .HasColumnName("AverageRating");
            
            b.Property(ar => ar.Count)
                .HasColumnName("RatingCount");
        });
    }
}