using CogLog.App.Contracts.Data.Category;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public class GetCategoryWithBlocksHandler(ICategoryRepo repo)
    : IRequestHandler<GetCategoryWithBlocksQuery, CategoryWithBlocksDto>
{
    public async Task<CategoryWithBlocksDto> Handle(
        GetCategoryWithBlocksQuery request,
        CancellationToken cancellationToken
    )
    {
        var category = await repo.GetCategoryWithRelationsAsync(request.Id, false, true);
        return category.ToCategoryWithBlocksDto();
    }
}
