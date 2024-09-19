using Dealoviy.Application.Common.Models;
using FluentValidation;

namespace Dealoviy.Application.Common.Validators;

public class ContactInfoModelValidator : AbstractValidator<ContactInfoModel>
{
    public ContactInfoModelValidator()
    {
            
        RuleFor(x => x.Value)
            .NotEmpty()
            .WithErrorCode("Validation.ContactInfo.Value.Empty")
            .WithMessage("Contact info value cannot be empty");
        
        RuleFor(x => x.Value)
            .MaximumLength(100)
            .WithErrorCode("Validation.ContactInfo.Value.TooLong")
            .WithMessage("Contact info value cannot be longer than 100 characters");
    }
}