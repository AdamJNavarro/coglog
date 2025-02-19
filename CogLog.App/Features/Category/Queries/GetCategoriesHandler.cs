using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public class GetCategoriesHandler(ICategoryRepo repo)
    : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken
    )
    {
        var categories = await repo.GetCategoriesAsync();
        return categories.ToCategoryDtos();
    }
}
