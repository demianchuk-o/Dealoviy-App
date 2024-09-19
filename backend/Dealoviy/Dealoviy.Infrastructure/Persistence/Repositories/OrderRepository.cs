using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Orders;
using Dealoviy.Infrastructure.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Dealoviy.Infrastructure.Persistence.Repositories;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(DealoviyDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddAsync(Order order)
    {
        await DbContext.Orders.AddAsync(order);
        await DbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetByServiceIdAsync(Guid serviceId)
    {
        return await DbContext.Orders
            .Where(o => o.ServiceId == serviceId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId)
    {
        return await DbContext.Orders
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid requestId)
    {
        return await DbContext.Orders
            .FirstOrDefaultAsync(o => o.Id == requestId);
    }

    public Task UpdateAsync(Order request)
    {
        DbContext.Orders.Update(request);
        return DbContext.SaveChangesAsync();
    }
}