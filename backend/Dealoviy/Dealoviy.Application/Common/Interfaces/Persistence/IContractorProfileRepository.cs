using Dealoviy.Domain.ContractorProfiles;

namespace Dealoviy.Application.Common.Interfaces.Persistence;

public interface IContractorProfileRepository
{
    Task<ContractorProfile?> GetByIdAsync(Guid id);
    Task AddAsync(ContractorProfile profile);
    Task UpdateAsync(ContractorProfile profile);
}