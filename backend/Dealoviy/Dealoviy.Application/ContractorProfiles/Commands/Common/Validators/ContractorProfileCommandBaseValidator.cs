using Dealoviy.Application.Common.Validators;
using Dealoviy.Application.ContractorProfiles.Commands.Common.Interfaces;
using FluentValidation;

namespace Dealoviy.Application.ContractorProfiles.Commands.Common.Validators;

public abstract class ContractorProfileCommandBaseValidator<TContractorProfileCommand> 
    : AbstractValidator<TContractorProfileCommand>
    where TContractorProfileCommand : IContractorProfileCommand
{
    protected ContractorProfileCommandBaseValidator()
    {
        RuleFor(x => x.AdditionalInfo)
            .NotEmpty()
            .WithErrorCode("Validation.AdditionalInfo.Required")
            .WithMessage("Additional info is required");
        
        RuleFor(x => x.ContactInfos)
            .NotEmpty()
            .WithErrorCode("Validation.ContactInfos.Required")
            .WithMessage("Contact infos are required");
        
        RuleForEach(x => x.ContactInfos)
            .SetValidator(new ContactInfoModelValidator());
    }
}