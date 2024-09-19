using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Common.Location;
using Dealoviy.Infrastructure.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Dealoviy.Infrastructure.Persistence.Repositories;

public class RegionRepository : BaseRepository, IRegionRepository
{
    public RegionRepository(DealoviyDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Region>> GetAllRegionsAsync()
    {
        return await DbContext.Regions.ToListAsync();
    }
    
    public async Task<Region?> GetRegionByIdAsync(Guid id)
    {
        return await DbContext.Regions.FirstOrDefaultAsync(region => region.Id == id);
    }
}