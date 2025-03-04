using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Category.Commands;

public class CreateCategoryHandler(ICategoryRepo repo) : IRequestHandler<CreateCategoryCommand, int>
{
    public async Task<int> Handle(
        CreateCategoryCommand request,
        CancellationToken cancellationToken
    )
    {
        var validator = new CreateCategoryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Category", validationResult);
        }

        var incomingCategory = request.ToCategory();

        await repo.CreateCategoryAsync(incomingCategory);

        return incomingCategory.Id;
    }
}
