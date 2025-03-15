using CogLog.App.Constants;
using CogLog.App.Contracts.Persistence;
using FluentValidation;

namespace CogLog.App.Features.Subject.Commands;

public class UpdateSubjectValidator : AbstractValidator<UpdateSubjectCommand>
{
    private readonly ICategoryRepo _categoryRepo;
    private readonly ISubjectRepo _subjectRepo;

    public UpdateSubjectValidator(ISubjectRepo subjectRepo, ICategoryRepo categoryRepo)
    {
        _subjectRepo = subjectRepo;
        _categoryRepo = categoryRepo;

        RuleFor(x => x.Id)
            .NotNull()
            .MustAsync(SubjectMustExist)
            .WithMessage("Subject does not exist!");

        // RuleFor(x => x.CategoryId)
        //     .NotNull()
        //     .MustAsync(CategoryMustExist)
        //     .WithMessage("Category does not exist!");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MinimumLength(ValidationConstants.Subject.NameMinLength)
            .WithMessage("{PropertyName} must be at least {MinLength} characters");
    }

    private async Task<bool> SubjectMustExist(int id, CancellationToken arg2)
    {
        return await _subjectRepo.EntityExistsAsync(id);
    }

    private async Task<bool> CategoryMustExist(int id, CancellationToken arg2)
    {
        return await _categoryRepo.EntityExistsAsync(id);
    }
}
