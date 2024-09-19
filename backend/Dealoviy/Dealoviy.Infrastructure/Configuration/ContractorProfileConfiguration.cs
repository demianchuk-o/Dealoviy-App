using Dealoviy.Domain.Common.ContactInfo;
using Dealoviy.Domain.ContractorProfiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dealoviy.Infrastructure.Configuration;

public class ContractorProfileConfiguration : IEntityTypeConfiguration<ContractorProfile>
{
    public void Configure(EntityTypeBuilder<ContractorProfile> builder)
    {
        builder.ToTable("ContractorProfiles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.AdditionalInfo).HasMaxLength(255);
        builder.OwnsMany<ContactInfo>(nameof(ContractorProfile.ContactInfos), b =>  
        {  
            b.WithOwner()  
                .HasForeignKey("UserId");  
  
            b.Property<int>("Id").
                ValueGeneratedOnAdd();
            
            b.HasKey("Id");  
  
            b.Property(ci => ci.Type)  
                .HasConversion<string>()  
                .HasMaxLength(20)  
                .IsRequired();  
  
            b.Property(ci => ci.Value)  
                .HasMaxLength(100)  
                .IsRequired();  
        });
    }
}