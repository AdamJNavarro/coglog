using CogLog.UI.Models.Category;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Contracts;

public interface ICategoryService
{
    Task<List<CategoryMinimalVm>> GetCategoriesAsync();

    Task<CategoryDetailsVm> GetCategoryDetailsAsync(int id);

    Task<Response<Guid>> CreateCategoryAsync(CategoryCreateVm category);
    Task<Response<Guid>> UpdateCategoryAsync(CategoryEditVm category);
    Task<Response<Guid>> DeleteCategoryAsync(int id);
    Task<List<SelectListItem>> GetSelectListAsync();
}
