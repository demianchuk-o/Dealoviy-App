using Dealoviy.Domain.Services;

namespace Dealoviy.Application.Common.Interfaces.Persistence;

public interface IServiceRepository
{
    Task<Service?> GetByIdAsync(Guid id);
    Task AddAsync(Service service);
    Task UpdateAsync(Service service);
    Task<IEnumerable<Service>> GetByKeywordAndCityAsync(string keyword, Guid cityId);
    Task<IEnumerable<Service>> GetByContractorIdAsync(Guid contractorId);
}