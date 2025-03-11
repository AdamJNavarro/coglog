using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Category.Commands;

public class UpdateCategoryHandler(ICategoryRepo repo)
    : IRequestHandler<UpdateCategoryCommand, Unit>
{
    public async Task<Unit> Handle(
        UpdateCategoryCommand request,
        CancellationToken cancellationToken
    )
    {
        // var existingCategory = await repo.GetCategoryAsync(request.Id);
        //
        // if (existingCategory is null)
        // {
        //     throw new NotFoundException(nameof(Category), request.Id);
        // }

        var validator = new UpdateCategoryValidator(repo);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Category", validationResult);
        }

        var category = request.ToCategory();
        await repo.UpdateCategoryAsync(category);
        return Unit.Value;
    }
}
