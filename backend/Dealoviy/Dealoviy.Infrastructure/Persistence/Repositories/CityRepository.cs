using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Common.Location;
using Dealoviy.Infrastructure.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Dealoviy.Infrastructure.Persistence.Repositories;

public class CityRepository : BaseRepository, ICityRepository
{
    
    public CityRepository(DealoviyDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<IEnumerable<City>> GetCitiesByRegionIdAsync(Guid regionId)
    {
        return await DbContext.Cities.
            Where(city => city.RegionId == regionId)
            .ToListAsync();
    }

    public async Task<City?> GetCityByIdAsync(Guid id)
    {
        return await DbContext.Cities
            .FirstOrDefaultAsync(city => city.Id == id);
    }
}