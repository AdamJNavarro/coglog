using CogLog.App.Constants;
using CogLog.App.Contracts.Persistence;
using FluentValidation;

namespace CogLog.App.Features.Word.Commands;

public class UpdateWordValidator : AbstractValidator<UpdateWordCommand>
{
    private readonly IWordRepo _wordRepo;

    public UpdateWordValidator(IWordRepo wordRepo)
    {
        _wordRepo = wordRepo;

        RuleFor(x => x.Id)
            .NotNull()
            .MustAsync(WordMustExist)
            .WithMessage("Category does not exist!");

        RuleFor(p => p.Spelling)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MinimumLength(ValidationConstants.Word.SpellingMinLength)
            .WithMessage("{PropertyName} must be at least {MinLength} characters");
    }

    private async Task<bool> WordMustExist(int id, CancellationToken arg2)
    {
        return await _wordRepo.EntityExistsAsync(id);
    }
}
