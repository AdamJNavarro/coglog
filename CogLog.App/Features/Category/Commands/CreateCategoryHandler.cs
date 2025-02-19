using CogLog.App.Contracts.Persistence;
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
        var incomingCategory = request.ToCategory();

        await repo.CreateCategoryAsync(incomingCategory);

        return incomingCategory.Id;
    }
}
