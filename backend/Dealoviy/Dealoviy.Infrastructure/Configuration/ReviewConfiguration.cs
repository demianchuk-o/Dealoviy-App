using Dealoviy.Domain.Reviews;
using Dealoviy.Domain.Services;
using Dealoviy.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dealoviy.Infrastructure.Configuration;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        
        builder.Property(x => x.ServiceId).IsRequired();
        builder.HasOne<Service>()
            .WithMany()
            .HasForeignKey(x => x.ServiceId);
        
        builder.Property(x => x.UserId).IsRequired();
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId);
        
        builder.Property(x => x.Rating).IsRequired();
        
        builder.Property(x => x.Text).IsRequired();
        builder.Property(x => x.Text).HasMaxLength(255);
        
        builder.Property(x => x.CreatedAt).IsRequired();
    }
}