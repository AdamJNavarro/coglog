using CogLog.App.Constants;
using FluentValidation;

namespace CogLog.App.Features.Word.Commands;

public class CreateWordValidator : AbstractValidator<CreateWordCommand>
{
    public CreateWordValidator()
    {
        RuleFor(p => p.Spelling)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MinimumLength(ValidationConstants.Word.SpellingMinLength)
            .WithMessage("{PropertyName} must be at least {MinLength} characters");
    }
}
