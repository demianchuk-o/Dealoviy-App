using Dealoviy.Domain.Common.ContactInfo;
using Dealoviy.Domain.Orders;
using Dealoviy.Domain.Services;
using Dealoviy.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dealoviy.Infrastructure.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
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
        
        builder.OwnsOne<ContactInfo>(nameof(Order.CustomerContactInfo), b =>
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

        builder.OwnsOne<ContactInfo>(nameof(Order.ContractorContactInfo), b =>
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
        builder.Property(request => request.OrderDate).IsRequired();
        
        builder.Property(request => request.OrderStatus)
            .HasConversion<string>();
    }
}