using Dealoviy.Domain.Common.ContactInfo;
using Dealoviy.Domain.Requests;
using Dealoviy.Domain.Services;
using Dealoviy.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dealoviy.Infrastructure.Configuration;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests");
        builder.HasKey(request => request.Id);
        builder.Property(request => request.Id).ValueGeneratedNever();
        
        builder.Property(request => request.ServiceId).IsRequired();
        builder.HasOne<Service>()
            .WithMany()
            .HasForeignKey(request => request.ServiceId);
        
        builder.Property(request => request.CustomerId).IsRequired();
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(request => request.CustomerId);
        
        builder.Property(request => request.Description).IsRequired();
        
        builder.OwnsOne<ContactInfo>(nameof(Request.CustomerContactInfo), b =>
        {
            b.Property(ci => ci.Type)
                .HasColumnName("CustomerContactType")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();
            b.Property(ci => ci.Value)
                .HasColumnName("CustomerContactValue")
                .HasMaxLength(100)
                .IsRequired();
        });

        builder.OwnsOne<ContactInfo>(nameof(Request.ContractorContactInfo), b =>
        {
            b.Property(ci => ci.Type)
                .HasColumnName("ContractorContactType")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();
            b.Property(ci => ci.Value)
                .HasColumnName("ContractorContactValue")
                .HasMaxLength(100)
                .IsRequired();
        });
        builder.Property(request => request.PaymentAmount).IsRequired();
        builder.Property(request => request.RequestDate).IsRequired();
        
        builder.Property(request => request.RequestStatus)
            .HasConversion<string>();
    }
}