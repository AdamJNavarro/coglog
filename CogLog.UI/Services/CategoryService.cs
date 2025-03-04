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
        var category = await _client.CategoryGETAsync(id);
        return category.ToBaseCategoryVm();
    }

    public async Task<CategoryWithSubjectsVm> GetCategoryWithSubjectsAsync(int id)
    {
        var data = await _client.CategoryWithSubjectsGETAsync(id);
        return data.ToCategoryWithSubjectsVm();
    }

    public async Task<Response<Guid>> CreateCategoryAsync(CreateCategoryVm category)
    {
        try
        {
            var cmd = category.ToCreateCategoryCommand();
            await _client.CategoriesPOSTAsync(cmd);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> UpdateCategoryAsync(BaseCategoryVm category)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Guid>> DeleteCategoryAsync(int id)
    {
        try
        {
            await _client.CategoriesDELETEAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
