using CogLog.App.Constants;
using CogLog.App.Contracts.Persistence;
using FluentValidation;

namespace CogLog.App.Features.Tag.Commands;

public class CreateTagValidator : AbstractValidator<CreateTagCommand>
{
    private readonly ISubjectRepo _subjectRepo;

    public CreateTagValidator(ISubjectRepo subjectRepo)
    {
        _subjectRepo = subjectRepo;

        RuleFor(x => x.SubjectId)
            .NotNull()
            .MustAsync(SubjectMustExist)
            .WithMessage("Subject does not exist!");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MinimumLength(ValidationConstants.Tag.NameMinLength)
            .WithMessage("{PropertyName} must be at least {MinLength} characters");
    }

    private async Task<bool> SubjectMustExist(int id, CancellationToken arg2)
    {
        return await _subjectRepo.EntityExistsAsync(id);
    }
}
