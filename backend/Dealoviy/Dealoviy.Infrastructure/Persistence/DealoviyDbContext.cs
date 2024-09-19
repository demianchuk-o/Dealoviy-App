using Dealoviy.Domain.Common.Location;
using Dealoviy.Domain.ContractorProfiles;
using Dealoviy.Domain.Orders;
using Dealoviy.Domain.Requests;
using Dealoviy.Domain.Reviews;
using Dealoviy.Domain.Services;
using Dealoviy.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Dealoviy.Infrastructure.Persistence;

public class DealoviyDbContext : DbContext
{
    public DealoviyDbContext(DbContextOptions<DealoviyDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Region> Regions { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<ContractorProfile> ContractorProfiles { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<Request> Requests { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DealoviyDbContext).Assembly);
        modelBuilder.SeedLocationData();
        base.OnModelCreating(modelBuilder);
    }
}