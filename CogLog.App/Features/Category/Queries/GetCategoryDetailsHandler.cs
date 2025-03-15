using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Data.Category;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public class GetCategoryDetailsHandler(ICategoryRepo repo)
    : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto>
{
    public async Task<CategoryDetailsDto> Handle(
        GetCategoryDetailsQuery request,
        CancellationToken cancellationToken
    )
    {
        var category = await repo.GetCategoryDetailsAsync(request.Id);
        if (category is null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        return category;
    }
}
