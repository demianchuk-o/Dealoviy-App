using Dealoviy.Contracts.Reviews;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Reviews.Queries.GetReviewsForService;

public record GetReviewsForServiceQuery(Guid ServiceId) 
    : IRequest<ErrorOr<IEnumerable<ReviewResponse>>>;