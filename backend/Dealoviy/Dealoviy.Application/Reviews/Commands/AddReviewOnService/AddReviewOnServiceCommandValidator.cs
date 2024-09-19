using FluentValidation;

namespace Dealoviy.Application.Reviews.Commands.AddReviewOnService;

public class AddReviewOnServiceCommandValidator 
    : AbstractValidator<AddReviewOnServiceCommand>
{
    public AddReviewOnServiceCommandValidator()
    {
        RuleFor(c => c.ServiceId)
            .NotEmpty()
            .WithErrorCode("Review.ServiceId.Required")
            .WithMessage("Service id is required.");
        
        RuleFor(c => c.UserId)
            .NotEmpty()
            .WithErrorCode("Review.UserId.Required")
            .WithMessage("User id is required.");
        
        RuleFor(c => c.Rating)
            .InclusiveBetween(1, 5)
            .WithErrorCode("Review.Rating.Invalid")
            .WithMessage("Rating must be between 1 and 5.");
        
        RuleFor(c => c.Text)
            .NotEmpty()
            .WithErrorCode("Review.Text.Required")
            .WithMessage("Text is required.");

        RuleFor(c => c.Text)
            .MaximumLength(255)
            .WithErrorCode("Review.Text.TooLong")
            .WithMessage("Text must be less than 255 characters.");
    }
}