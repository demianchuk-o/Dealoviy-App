using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Reviews.Commands.AddReviewOnService;

public record AddReviewOnServiceCommand(
    Guid ServiceId,
    Guid UserId,
    int Rating,
    string Text) : IRequest<ErrorOr<Unit>>;