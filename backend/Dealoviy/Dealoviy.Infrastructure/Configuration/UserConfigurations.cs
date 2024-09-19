using Dealoviy.Domain.ContractorProfiles;
using Dealoviy.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dealoviy.Infrastructure.Configuration;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Id)
            .ValueGeneratedNever();
        
        builder.Property(u => u.Username)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(u => u.Username)
            .IsUnique();
        
        builder.Property(u => u.DisplayName)
            .HasMaxLength(50);

        builder.Property(u => u.DisplayName)
            .HasMaxLength(50);
        
        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.HasOne<ContractorProfile>()
            .WithOne()
            .HasForeignKey<User>(u => u.ContractorProfileId);
    }
}