using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class GenericRepo<T>(AppDbContext context) : IGenericRepo<T>
    where T : BaseEntity
{
    public async Task CreateAsync(T entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<IReadOnlyList<T>> GetAsync()
    {
        return await context.Set<T>().AsNoTracking().ToListAsync();
    }
}
