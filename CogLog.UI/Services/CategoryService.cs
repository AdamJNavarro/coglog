using CogLog.UI.Contracts;
using CogLog.UI.Mapping;
using CogLog.UI.Models.Category;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Services;

public class CategoryService(IClient client, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        ICategoryService
{
    private readonly IClient _client = client;

    public async Task<List<BaseCategoryVm>> GetCategoriesAsync()
    {
        var categories = await _client.CategoriesAllAsync();
        return categories.ToBaseCategoriesVm();
    }

    public async Task<BaseCategoryVm> GetCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryWithSubjectsVm> GetCategoryWithSubjectsAsync(int id)
    {
        var data = await _client.CategoryWithSubjectsGETAsync(id);
        return data.ToCategoryWithSubjectsVm();
    }

    public async Task<Response<Guid>> CreateCategoryAsync(BaseCategoryVm category)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Guid>> UpdateCategoryAsync(BaseCategoryVm category)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Guid>> DeleteCategoryAsync(int id)
    {
        throw new NotImplementedException();
    }
}
