using Dealoviy.Domain.Users;

namespace Dealoviy.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByUsernameAsync(string username);
    Task<User?> GetByContractorIdAsync(Guid contractorId);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}