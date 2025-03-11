using CogLog.UI.Models.Category;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface ICategoryService
{
    Task<List<BaseCategoryVm>> GetCategoriesAsync();

    Task<BaseCategoryVm> GetCategoryAsync(int id);

    Task<CategoryWithSubjectsVm> GetCategoryWithSubjectsAsync(int id);

    Task<Response<Guid>> CreateCategoryAsync(CategoryCreateVm category);
    Task<Response<Guid>> UpdateCategoryAsync(CategoryEditVm category);
    Task<Response<Guid>> DeleteCategoryAsync(int id);
}
