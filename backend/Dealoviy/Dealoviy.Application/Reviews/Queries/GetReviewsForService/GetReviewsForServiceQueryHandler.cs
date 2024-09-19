using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Contracts.Reviews;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Users;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Reviews.Queries.GetReviewsForService;

public class GetReviewsForServiceQueryHandler
    : IRequestHandler<GetReviewsForServiceQuery, 
        ErrorOr<IEnumerable<ReviewResponse>>>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IUserRepository _userRepository;

    public GetReviewsForServiceQueryHandler(
        IReviewRepository reviewRepository, 
        IServiceRepository serviceRepository, 
        IUserRepository userRepository)
    {
        _reviewRepository = reviewRepository;
        _serviceRepository = serviceRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<IEnumerable<ReviewResponse>>> Handle(
        GetReviewsForServiceQuery request, 
        CancellationToken cancellationToken)
    {
        if (await _serviceRepository.GetByIdAsync(request.ServiceId)
            is null)
        {
            return Errors.ServiceNotFound;
        }
        
        var reviews = await _reviewRepository.GetReviewsByServiceId(request.ServiceId);

        var customerTasks = reviews
            .Select(r => _userRepository.GetUserByIdAsync(r.UserId));
        
        var customers = new List<User>();
        
        foreach (var task in customerTasks)
        {
            customers.Add(await task);
        }
        
        var reviewResponses = reviews
            .Zip(customers, (review, customer) => new ReviewResponse(
                review.Id,
                customer.GetDisplayName(),
                review.Text,
                review.CreatedAt,
                review.Rating))
            .OrderByDescending(r => r.ReviewDate)
            .ToList();
        
        return reviewResponses;
    }
}