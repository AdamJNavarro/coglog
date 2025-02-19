using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Data.Category;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public class GetCategoryWithSubjectsHandler(ICategoryRepo repo)
    : IRequestHandler<GetCategoryWithSubjectsQuery, CategoryWithSubjectsDto>
{
    public async Task<CategoryWithSubjectsDto> Handle(
        GetCategoryWithSubjectsQuery request,
        CancellationToken cancellationToken
    )
    {
        var category = await repo.GetCategoryWithRelationsAsync(request.Id, true, false);
        return category.ToCategoryWithSubjectsDto();
    }
}
