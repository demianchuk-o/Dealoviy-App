using Dealoviy.Domain.Requests;

namespace Dealoviy.Application.Common.Interfaces.Persistence;

public interface IRequestRepository
{
    Task AddAsync(Request request);
    Task<IEnumerable<Request>> GetByServiceIdAsync(Guid serviceId);
    Task<IEnumerable<Request>> GetByCustomerIdAsync(Guid customerId);
    
    Task<Request?> GetByIdAsync(Guid requestId);
    
    Task UpdateAsync(Request request);
    Task DeleteAsync(Request request);
}