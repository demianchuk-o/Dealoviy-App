using Dealoviy.Domain.Common.Location;

namespace Dealoviy.Application.Common.Interfaces.Persistence;

public interface IRegionRepository
{
    Task<IEnumerable<Region>> GetAllRegionsAsync();
    Task<Region?> GetRegionByIdAsync(Guid id);
}