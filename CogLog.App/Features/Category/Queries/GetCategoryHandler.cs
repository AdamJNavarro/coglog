using CogLog.App.Contracts.Data.Category;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public class GetCategoryHandler(ICategoryRepo repo) : IRequestHandler<GetCategoryQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(
        GetCategoryQuery request,
        CancellationToken cancellationToken
    )
    {
        var category = await repo.GetCategoryAsync(request.Id);

        if (category is null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        return category.ToCategoryDto();
    }
}
