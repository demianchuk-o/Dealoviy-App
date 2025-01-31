﻿using Dealoviy.Application.Authentication.Common;

using ErrorOr;
using MediatR;

namespace Dealoviy.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Username,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;