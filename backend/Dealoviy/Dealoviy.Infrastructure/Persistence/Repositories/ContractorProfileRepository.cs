using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.ContractorProfiles;
using Dealoviy.Infrastructure.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Dealoviy.Infrastructure.Persistence.Repositories;

public class ContractorProfileRepository : BaseRepository, IContractorProfileRepository
{
    public ContractorProfileRepository(DealoviyDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<ContractorProfile?> GetByIdAsync(Guid id)
    {
        return await DbContext.ContractorProfiles
            .FirstOrDefaultAsync(profile => profile.Id == id);
    }

    public async Task AddAsync(ContractorProfile profile)
    {
        await DbContext.ContractorProfiles.AddAsync(profile);
        await DbContext.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(ContractorProfile profile)
    {
        DbContext.ContractorProfiles.Update(profile);
        await DbContext.SaveChangesAsync();
    }
}