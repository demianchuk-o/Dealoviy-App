using Dealoviy.Domain.Reviews;

namespace Dealoviy.Application.Common.Interfaces.Persistence;

public interface IReviewRepository
{
    Task AddReview(Review review);
    Task<IEnumerable<Review>> GetReviewsByServiceId(Guid serviceId);
}