using CogLog.App.Contracts.Data.Category;
using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface ICategoryRepo : IBaseRepo<Category>
{
    Task CreateCategoryAsync(Category category);

    Task<List<Category>> GetCategoriesAsync();

    Task<CategoryDetailsDto?> GetCategoryDetailsAsync(int id);

    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Category category);
}
