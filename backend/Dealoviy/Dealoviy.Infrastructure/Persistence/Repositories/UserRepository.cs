using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Users;
using Dealoviy.Infrastructure.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Dealoviy.Infrastructure.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{

    public UserRepository(DealoviyDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await DbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
    }
    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await DbContext.Users.FirstOrDefaultAsync(user => user.Username == username);
    }
    
    public async Task<User?> GetByContractorIdAsync(Guid contractorId)
    {
        return await DbContext.Users.FirstOrDefaultAsync(user => user.ContractorProfileId == contractorId);
    }

    public async Task AddAsync(User user)
    {
        await DbContext.Users.AddAsync(user);
        await DbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        DbContext.Users.Update(user);
        await DbContext.SaveChangesAsync();
    }
}