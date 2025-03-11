using CogLog.App.Constants;
using CogLog.App.Contracts.Persistence;
using FluentValidation;

namespace CogLog.App.Features.Category.Commands;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    private readonly ICategoryRepo _categoryRepo;

    public UpdateCategoryValidator(ICategoryRepo categoryRepo)
    {
        _categoryRepo = categoryRepo;

        RuleFor(x => x.Id)
            .NotNull()
            .MustAsync(CategoryMustExist)
            .WithMessage("Category does not exist!");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MinimumLength(ValidationConstants.Category.NameMinLength)
            .WithMessage("{PropertyName} must be at least {MinLength} characters");
    }

    private async Task<bool> CategoryMustExist(int id, CancellationToken arg2)
    {
        return await _categoryRepo.EntityExistsAsync(id);
    }
}
