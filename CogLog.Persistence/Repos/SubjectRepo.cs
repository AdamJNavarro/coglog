using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class SubjectRepo(AppDbContext ctx) : BaseRepo<Subject>(ctx), ISubjectRepo
{
    private readonly AppDbContext _ctx = ctx;

    public async Task CreateSubjectAsync(Subject subject)
    {
        await _ctx.Subjects.AddAsync(subject);
        await _ctx.SaveChangesAsync();
    }

    public async Task<List<Subject>> GetSubjectsAsync()
    {
        return await _ctx.Subjects.AsNoTracking().ToListAsync();
    }

    public async Task<Subject> GetSubjectWithRelationsAsync(
        int id,
        bool includeCategory,
        bool includeTopics,
        bool includeTags,
        bool includeBrainBlocks
    )
    {
        var query = _ctx.Subjects.AsQueryable();
        if (includeCategory)
        {
            query = query.Include(x => x.Category);
        }

        if (includeTopics)
        {
            query = query.Include(x => x.Topics);
        }

        if (includeTags)
        {
            query = query.Include(x => x.Tags);
        }

        if (includeBrainBlocks)
        {
            query = query.Include(x => x.BrainBlocks);
        }

        return await query.SingleAsync(q => q.Id == id);
    }

    public async Task UpdateSubjectAsync(Subject subject)
    {
        _ctx.Entry(subject).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteSubjectAsync(Subject subject)
    {
        _ctx.Subjects.Remove(subject);
        await _ctx.SaveChangesAsync();
    }
}
