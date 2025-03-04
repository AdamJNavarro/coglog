using FluentValidation;

namespace CogLog.App.Features.Category.Commands;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Label).NotEmpty().NotNull().WithMessage("Label needed noob.");
    }
}
