using CogLog.UI.Models.Category;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface ICategoryService
{
    Task<List<BaseCategoryVm>> GetCategoriesAsync();

    Task<BaseCategoryVm> GetCategoryAsync(int id);

    Task<CategoryWithSubjectsVm> GetCategoryWithSubjectsAsync(int id);

    Task<Response<Guid>> CreateCategoryAsync(BaseCategoryVm category);
    Task<Response<Guid>> UpdateCategoryAsync(BaseCategoryVm category);
    Task<Response<Guid>> DeleteCategoryAsync(int id);
}
