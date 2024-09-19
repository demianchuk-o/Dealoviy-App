using Dealoviy.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Dealoviy.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Username,
    string? DisplayName,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;