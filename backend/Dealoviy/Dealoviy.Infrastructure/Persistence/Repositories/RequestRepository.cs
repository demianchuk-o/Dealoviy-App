using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Requests;
using Dealoviy.Infrastructure.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Dealoviy.Infrastructure.Persistence.Repositories;

public class RequestRepository : BaseRepository, IRequestRepository
{
    public RequestRepository(DealoviyDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddAsync(Request request)
    {
        await DbContext.Requests.AddAsync(request);
        await DbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Request>> GetByServiceIdAsync(Guid serviceId)
    {
        return await DbContext.Requests
            .Where(r => r.ServiceId == serviceId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Request>> GetByCustomerIdAsync(Guid customerId)
    {
        return await DbContext.Requests
            .Where(r => r.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<Request?> GetByIdAsync(Guid requestId)
    {
        return await DbContext.Requests
            .FirstOrDefaultAsync(r => r.Id == requestId);
    }

    public async Task UpdateAsync(Request request)
    {
        DbContext.Requests.Update(request);
        await DbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Request request)
    {
        DbContext.Requests.Remove(request);
        await DbContext.SaveChangesAsync();
    }
}