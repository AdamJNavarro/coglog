using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public class GetCategoryWithBrainBlocksHandler(ICategoryRepo repo)
    : IRequestHandler<GetCategoryWithBrainBlocksQuery, CategoryWithBrainBlocksDto>
{
    public async Task<CategoryWithBrainBlocksDto> Handle(
        GetCategoryWithBrainBlocksQuery request,
        CancellationToken cancellationToken
    )
    {
        var category = await repo.GetCategoryWithRelationsAsync(request.Id, false, true);
        return category.ToCategoryWithBrainBlocksDto();
    }
}
