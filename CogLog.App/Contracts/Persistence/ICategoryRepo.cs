using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface ICategoryRepo : IBaseRepo<Category>
{
    Task CreateCategoryAsync(Category category);

    Task<List<Category>> GetCategoriesAsync();

    Task<Category?> GetCategoryAsync(int id);

    Task<Category> GetCategoryWithRelationsAsync(
        int id,
        bool includeSubjects,
        bool includeBrainBlocks
    );

    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(Category category);
}
