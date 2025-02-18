using CogLog.App.Contracts.Persistence;
using CogLog.Domain.Hierarchy;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class CategoryRepo(AppDbContext ctx) : ICategoryRepo
{
    public async Task CreateCategoryAsync(Category category)
    {
        await ctx.Categories.AddAsync(category);
        await ctx.SaveChangesAsync();
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await ctx.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<Category> GetCategoryWithRelationsAsync(
        int id,
        bool includeSubjects = true,
        bool includeBrainBlocks = false
    )
    {
        var q = ctx.Categories.AsQueryable();
        if (includeSubjects)
        {
            q = q.Include(qq => qq.Subjects);
        }

        if (includeBrainBlocks)
        {
            q = q.Include(qq => qq.BrainBlocks);
        }
        return await q.SingleAsync(qq => qq.Id == id);
    }

    public async Task DeleteCategoryAsync(Category category)
    {
        ctx.Categories.Remove(category);
        await ctx.SaveChangesAsync();
    }
}
