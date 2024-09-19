using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Services;
using Dealoviy.Infrastructure.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Dealoviy.Infrastructure.Persistence.Repositories;

public class ServiceRepository : BaseRepository, IServiceRepository
{
    public ServiceRepository(DealoviyDbContext dbContext) : base(dbContext)
    {
    }


    public async Task<Service?> GetByIdAsync(Guid id)
    {
        return await DbContext.Services.FirstOrDefaultAsync(service => service.Id == id);
    }

    public async Task AddAsync(Service service)
    {
        await DbContext.Services.AddAsync(service);
        await DbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Service service)
    {
        DbContext.Services.Update(service);
        await DbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Service>> GetByKeywordAndCityAsync(string keyword, Guid cityId)
    {
        return await DbContext.Services
            .Where(service => service.Name.Contains(keyword) 
                              && service.CityId == cityId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Service>> GetByContractorIdAsync(Guid contractorId)
    {
        return await DbContext.Services
            .Where(service => service.ContractorId == contractorId)
            .ToListAsync();
    }
}