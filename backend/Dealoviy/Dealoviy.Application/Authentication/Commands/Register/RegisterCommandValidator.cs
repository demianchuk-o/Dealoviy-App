using FluentValidation;

namespace Dealoviy.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithErrorCode("Validation.Username.Empty")
            .WithMessage("Username cannot be empty");

        RuleFor(x => x.Username)
            .MaximumLength(20)
            .WithErrorCode("Validation.FirstName.TooLong")
            .WithMessage("First name cannot be longer than 20 characters");
        
        RuleFor(x => x.DisplayName)
            .MaximumLength(50)
            .WithErrorCode("Validation.DisplayName.TooLong")
            .WithMessage("Display name cannot be longer than 50 characters");
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithErrorCode("Validation.Password.Empty")
            .WithMessage("Password cannot be empty");
        
        RuleFor(x => x.Password)
            .MinimumLength(8)
            .WithErrorCode("Validation.Password.TooShort")
            .WithMessage("Password cannot be shorter than 8 characters");
        
        RuleFor(x => x.Password)
            .MaximumLength(50)
            .WithErrorCode("Validation.Password.TooLong")
            .WithMessage("Password cannot be longer than 50 characters");
    }
}
