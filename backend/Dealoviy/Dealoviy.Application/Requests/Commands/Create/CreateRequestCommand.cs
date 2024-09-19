using Dealoviy.Application.Common.Models;
using MediatR;
using ErrorOr;
namespace Dealoviy.Application.Requests.Commands.Create;

public record CreateRequestCommand(
        Guid ServiceId,
        Guid CustomerId,
        string Description,
        ContactInfoModel CustomerContactInfo,
        int PaymentAmount) : IRequest<ErrorOr<Unit>>;