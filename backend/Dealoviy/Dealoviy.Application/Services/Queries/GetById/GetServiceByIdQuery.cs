using Dealoviy.Application.Services.Queries.Common;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Services.Queries.GetById;

public record GetServiceByIdQuery(Guid Id)
    : IRequest<ErrorOr<ServiceResult>>;