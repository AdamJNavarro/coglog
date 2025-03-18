using CogLog.App.Constants;
using CogLog.App.Contracts.Persistence;
using FluentValidation;

namespace CogLog.App.Features.Tag.Commands;

public class UpdateTagValidator : AbstractValidator<UpdateTagCommand>
{
    private readonly ISubjectRepo _subjectRepo;
    private readonly ITagRepo _tagRepo;

    public UpdateTagValidator(ITagRepo tagRepo, ISubjectRepo subjectRepo)
    {
        _subjectRepo = subjectRepo;
        _tagRepo = tagRepo;

        RuleFor(x => x.Id).NotNull().MustAsync(TagMustExist).WithMessage("Tag does not exist!");

        RuleFor(x => x.SubjectId)
            .NotNull()
            .MustAsync(SubjectMustExist)
            .WithMessage("Subject does not exist!");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MinimumLength(ValidationConstants.Hierarchy.NameMinLength)
            .WithMessage("{PropertyName} must be at least {MinLength} characters");
    }

    private async Task<bool> SubjectMustExist(int id, CancellationToken arg2)
    {
        return await _subjectRepo.EntityExistsAsync(id);
    }

    private async Task<bool> TagMustExist(int id, CancellationToken arg2)
    {
        return await _tagRepo.EntityExistsAsync(id);
    }
}
