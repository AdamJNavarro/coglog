using FluentValidation;

namespace CogLog.App.Features.Category.Commands;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("Name needed noob.");
    }
}
