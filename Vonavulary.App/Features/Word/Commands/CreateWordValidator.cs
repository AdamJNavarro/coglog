using FluentValidation;
using Vonavulary.App.Constants;
using Vonavulary.App.Contracts.Persistence;

namespace Vonavulary.App.Features.Word.Commands;

public class CreateWordValidator : AbstractValidator<CreateWordCommand>
{
    private readonly IWordRepo _wordRepo;

    public CreateWordValidator(IWordRepo wordRepo)
    {
        _wordRepo = wordRepo;

        RuleFor(p => p.Spelling)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MinimumLength(ValidationConstants.Word.SpellingMinLength)
            .WithMessage("{PropertyName} must be at least {MinLength} characters");

        RuleFor(x => x.Spelling)
            .NotNull()
            .MustAsync(WordMustBeUnique)
            .WithMessage("Category does not exist!");
    }

    private async Task<bool> WordMustBeUnique(string spelling, CancellationToken arg2)
    {
        return await _wordRepo.IsWordUnique(spelling);
    }
}
