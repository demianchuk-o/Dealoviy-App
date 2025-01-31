﻿using Dealoviy.Application.Services.Common.Interfaces;
using MediatR;
using ErrorOr;

namespace Dealoviy.Application.Services.Commands.Create;

public record CreateServiceCommand(
    Guid UserId,
    Guid CityId,
    string Name,
    string Description,
    int LowerPriceBound,
    int UpperPriceBound)
    : IServiceCommand, 
        IRequest<ErrorOr<Unit>>;