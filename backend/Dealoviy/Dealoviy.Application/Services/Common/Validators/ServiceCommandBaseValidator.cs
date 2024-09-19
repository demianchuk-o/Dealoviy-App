using Dealoviy.Application.Services.Common.Interfaces;
using FluentValidation;

namespace Dealoviy.Application.Services.Common.Validators;

public abstract class ServiceCommandBaseValidator<TServiceCommand>
    : AbstractValidator<TServiceCommand>
    where TServiceCommand : IServiceCommand
{
    protected ServiceCommandBaseValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithErrorCode("Validation.Service.Name.Required")
            .WithMessage("Service name is required");
        
        RuleFor(x => x.Name)
            .MaximumLength(100)
            .WithErrorCode("Validation.Service.Name.MaxLength")
            .WithMessage("Service name cannot be longer than 100 characters");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithErrorCode("Validation.Service.Description.Required")
            .WithMessage("Service description is required");
        
        RuleFor(x => x.Description)
            .MaximumLength(255)
            .WithErrorCode("Validation.Service.Description.MaxLength")
            .WithMessage("Service description cannot be longer than 255 characters");
    }
}