using Dealoviy.Domain.Common.Location;

namespace Dealoviy.Application.Common.Interfaces.Persistence;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetCitiesByRegionIdAsync(Guid regionId);
    Task<City?> GetCityByIdAsync(Guid id);
}