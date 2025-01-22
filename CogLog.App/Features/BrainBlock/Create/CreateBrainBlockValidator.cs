using FluentValidation;

namespace CogLog.App.Features.BrainBlock.Create;

internal class CreateBrainBlockValidator : AbstractValidator<CreateBrainBlockCommand>
{
    public CreateBrainBlockValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MinimumLength(4)
            .WithMessage("{PropertyName} must be at least {MinLength} characters");

        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MinimumLength(16)
            .WithMessage("{PropertyName} must be at least {MinLength} characters");

        RuleFor(x => x.Variant).IsInEnum();
    }
}
