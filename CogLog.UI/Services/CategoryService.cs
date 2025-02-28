using CogLog.UI.Contracts;
using CogLog.UI.Models.Category;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Services;

public class CategoryService(IClient client, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        ICategoryService
{
    private readonly IClient _client = client;

    public async Task<List<CategoryVm>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryVm> GetCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Guid>> CreateCategoryAsync(CategoryVm category)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Guid>> UpdateCategoryAsync(CategoryVm category)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Guid>> DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }
}
