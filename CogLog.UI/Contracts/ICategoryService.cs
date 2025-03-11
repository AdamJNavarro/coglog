using CogLog.UI.Models.Category;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Contracts;

public interface ICategoryService
{
    Task<List<BaseCategoryVm>> GetCategoriesAsync();

    Task<BaseCategoryVm> GetCategoryAsync(int id);

    Task<CategoryDetailsVm> GetCategoryDetailsAsync(int id);

    Task<Response<Guid>> CreateCategoryAsync(CategoryCreateVm category);
    Task<Response<Guid>> UpdateCategoryAsync(CategoryEditVm category);
    Task<Response<Guid>> DeleteCategoryAsync(int id);
    Task<List<SelectListItem>> GetSelectListAsync();
}
