using CogLog.Domain.Hierarchy;

namespace CogLog.App.Contracts.Persistence;

public interface ICategoryRepo
{
    Task CreateCategoryAsync(Category category);

    Task<List<Category>> GetCategoriesAsync();

    Task<Category> GetCategoryWithRelationsAsync(
        int id,
        bool includeSubjects,
        bool includeBrainBlocks
    );
    Task DeleteCategoryAsync(Category category);
}
