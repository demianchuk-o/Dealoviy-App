using Dealoviy.Application.Common.Interfaces.Persistence;
using Dealoviy.Application.Common.Interfaces.Services;
using Dealoviy.Domain.Common.Errors;
using Dealoviy.Domain.Reviews;
using MediatR;
using ErrorOr;
namespace Dealoviy.Application.Reviews.Commands.AddReviewOnService;

public class AddReviewOnServiceCommandHandler
    : IRequestHandler<AddReviewOnServiceCommand, ErrorOr<Unit>>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;
    private readonly IServiceRepository _serviceRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public AddReviewOnServiceCommandHandler(
        IReviewRepository reviewRepository, 
        IUserRepository userRepository, 
        IServiceRepository serviceRepository, 
        IDateTimeProvider dateTimeProvider)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
        _serviceRepository = serviceRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<Unit>> Handle(AddReviewOnServiceCommand request, CancellationToken cancellationToken)
    {
        if (await _serviceRepository.GetByIdAsync(request.ServiceId)
            is not { } service)
        {
            return Errors.ServiceNotFound;
        }
        
        if (await _userRepository.GetUserByIdAsync(request.UserId)
            is null)
        {
            return Errors.UserNotFound;
        }
        
        var review = Review.Create(
            request.ServiceId,
            request.UserId,
            request.Rating,
            request.Text,
            _dateTimeProvider.UtcNow);
        
        await _reviewRepository.AddReview(review);
        
        service.AverageRating.AddRating(review.Rating);
        await _serviceRepository.UpdateAsync(service);

        return Unit.Value;
    }
}