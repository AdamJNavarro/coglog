using CogLog.App.Contracts.Data.Category;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class CategoryRepo(AppDbContext ctx) : BaseRepo<Category>(ctx), ICategoryRepo
{
    private readonly AppDbContext _ctx = ctx;

    public async Task CreateCategoryAsync(Category category)
    {
        await _ctx.Categories.AddAsync(category);
        await _ctx.SaveChangesAsync();
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _ctx.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<CategoryDetailsDto?> GetCategoryDetailsAsync(int id)
    {
        var category = await _ctx
            .Categories.Include(x => x.Subjects)
            .SingleOrDefaultAsync(x => x.Id == id);
        return category.ToCategoryDetailsDto();
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        _ctx.Entry(category).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(Category category)
    {
        _ctx.Categories.Remove(category);
        await _ctx.SaveChangesAsync();
    }
}
