using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Domain.Reviews;
using Dealoviy.Infrastructure.Persistence.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Dealoviy.Infrastructure.Persistence.Repositories;

public class ReviewRepository : BaseRepository, IReviewRepository
{
    public ReviewRepository(DealoviyDbContext dbContext) : base(dbContext)
    {
    }

    public async Task AddReview(Review review)
    {
        await DbContext.Reviews.AddAsync(review);
        await DbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Review>> GetReviewsByServiceId(Guid serviceId)
    {
        return await DbContext.Reviews
            .Where(r => r.ServiceId == serviceId)
            .ToListAsync();
    }
}