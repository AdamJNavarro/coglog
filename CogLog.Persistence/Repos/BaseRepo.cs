using CogLog.App.Contracts.Persistence;
using CogLog.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class BaseRepo<T>(AppDbContext ctx) : IBaseRepo<T>
    where T : BaseEntity
{
    public async Task<bool> EntityExistsAsync(int id)
    {
        return await ctx.Set<T>().AnyAsync(q => q.Id == id);
    }

    public async Task<T?> GetEntityAsync(int id)
    {
        return await ctx.Set<T>().AsNoTracking().SingleOrDefaultAsync(q => q.Id == id);
    }
}
