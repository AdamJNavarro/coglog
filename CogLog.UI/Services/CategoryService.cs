using CogLog.UI.Contracts;
using CogLog.UI.Mapping;
using CogLog.UI.Models.Category;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Services;

public class CategoryService(IClient client, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        ICategoryService
{
    private readonly IClient _client = client;

    public async Task<List<CategoryMinimalVm>> GetCategoriesAsync()
    {
        var categories = await _client.CategoriesGetAsync();
        return categories.ToCategoryMinimalVmList();
    }

    public async Task<CategoryDetailsVm> GetCategoryDetailsAsync(int id)
    {
        var data = await _client.CategoryGetDetailsAsync(id);
        return data.ToCategoryDetailsVm();
    }

    public async Task<Response<Guid>> CreateCategoryAsync(CategoryCreateVm category)
    {
        try
        {
            var cmd = category.ToCreateCategoryCommand();
            await _client.CategoryCreateAsync(cmd);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> UpdateCategoryAsync(CategoryEditVm category)
    {
        try
        {
            var cmd = category.ToUpdateCategoryCommand();
            await _client.CategoryUpdateAsync(category.Id.ToString(), cmd);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteCategoryAsync(int id)
    {
        try
        {
            await _client.CategoryDeleteAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<List<SelectListItem>> GetSelectListAsync()
    {
        var categories = await _client.CategoriesGetAsync();
        ;
        return categories
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            .ToList();
    }
}
