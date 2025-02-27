using CogLog.UI.Models.Category;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface ICategoryService
{
    Task<List<CategoryVm>> GetCategoriesAsync();

    Task<CategoryVm> GetCategoryAsync(int id);

    Task<Response<Guid>> CreateCategoryAsync(CategoryVm category);
    Task<Response<Guid>> UpdateCategoryAsync(CategoryVm category);
    Task<Response<Guid>> DeleteCategoryAsync(int id);
}
