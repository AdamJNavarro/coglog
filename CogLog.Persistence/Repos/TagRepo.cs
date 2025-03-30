using CogLog.App.Contracts.Data.Tag;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
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

    public async Task<TagDetailsDto?> GetTagDetailsAsync(int id)
    {
        var data = await _ctx.Tags.Include(x => x.Subject).SingleOrDefaultAsync(x => x.Id == id);
        return data.ToTagDetailsDto();
    }

    public async Task<List<TagMinimalDto>> GetAllTagsAsync(int? subjectId = null)
    {
        var query = _ctx.Tags.AsNoTracking();

        query = query.OrderBy(q => q.Name);

        if (subjectId.HasValue)
        {
            query = query.Where(x => x.SubjectId == subjectId.Value);
        }

        var tags = await query.ToListAsync();

        return tags.ToTagMinimalDtoList();
    }
}
