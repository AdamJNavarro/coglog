using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class TagRepo(AppDbContext ctx) : BaseRepo<Tag>(ctx), ITagRepo
{
    private readonly AppDbContext _ctx = ctx;

    public async Task CreateTagAsync(Tag tag)
    {
        _ctx.Tags.Add(tag);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateTagAsync(Tag tag)
    {
        _ctx.Entry(tag).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteTagAsync(Tag tag)
    {
        _ctx.Tags.Remove(tag);
        await _ctx.SaveChangesAsync();
    }

    public async Task<Tag?> GetTagAsync(int id)
    {
        return await _ctx.Tags.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
    }
}
