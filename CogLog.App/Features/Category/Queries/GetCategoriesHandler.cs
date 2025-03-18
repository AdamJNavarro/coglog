using CogLog.App.Contracts.Data.Category;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public class GetCategoriesHandler(ICategoryRepo categoryRepo)
    : IRequestHandler<GetCategoriesQuery, List<CategoryMinimalDto>>
{
    public async Task<List<CategoryMinimalDto>> Handle(
        GetCategoriesQuery request,
        CancellationToken cancellationToken
    )
    {
        var categories = await categoryRepo.GetCategoriesAsync();
        return categories.ToCategoryMinimalDtoList();
    }
}
