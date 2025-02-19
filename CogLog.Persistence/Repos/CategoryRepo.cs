using CogLog.App.Contracts.Persistence;
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

    public async Task<Category?> GetCategoryAsync(int id)
    {
        return await _ctx.Categories.AsNoTracking().SingleOrDefaultAsync(q => q.Id == id);
    }

    public async Task<Category> GetCategoryWithRelationsAsync(
        int id,
        bool includeSubjects = true,
        bool includeBlocks = false
    )
    {
        var q = _ctx.Categories.AsQueryable();
        if (includeSubjects)
        {
            q = q.Include(qq => qq.Subjects);
        }

        if (includeBlocks)
        {
            q = q.Include(qq => qq.Blocks);
        }
        return await q.SingleAsync(qq => qq.Id == id);
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
