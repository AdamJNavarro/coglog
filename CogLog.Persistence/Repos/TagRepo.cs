using CogLog.App.Contracts.Persistence;
using CogLog.Domain;

namespace CogLog.Persistence.Repos;

public class TagRepo(AppDbContext ctx) : BaseRepo<Tag>(ctx), ITagRepo
{
    private readonly AppDbContext _ctx = ctx;

    public async Task CreateTagAsync(Tag tag)
    {
        _ctx.Tags.Add(tag);
        await _ctx.SaveChangesAsync();
    }
}
