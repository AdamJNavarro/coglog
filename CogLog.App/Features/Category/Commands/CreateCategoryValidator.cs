using CogLog.App.Constants;
using FluentValidation;

namespace CogLog.App.Features.Category.Commands;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MinimumLength(ValidationConstants.Hierarchy.NameMinLength)
            .WithMessage("{PropertyName} must be at least {MinLength} characters");
    }
}
