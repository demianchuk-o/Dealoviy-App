using Dealoviy.Domain.Orders;

namespace Dealoviy.Application.Common.Interfaces.Persistence;

public interface IOrderRepository
{
    Task AddAsync(Order request);
    Task<IEnumerable<Order>> GetByServiceIdAsync(Guid serviceId);
    Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId);
    
    Task<Order?> GetByIdAsync(Guid requestId);
    
    Task UpdateAsync(Order request);
}