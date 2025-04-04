using Microsoft.EntityFrameworkCore;
using Vonavulary.App.Contracts.Persistence;
using Vonavulary.Domain.Shared;

namespace Vonavulary.Persistence.Repos;

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
