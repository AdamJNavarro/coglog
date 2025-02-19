using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class BrainBlockRepo(AppDbContext ctx) : BaseRepo<BrainBlock>(ctx), IBrainBlockRepo
{
    private readonly AppDbContext _ctx = ctx;

    public async Task CreateBrainBlockAsync(BrainBlock brainBlock)
    {
        await _ctx.BrainBlocks.AddAsync(brainBlock);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateBrainBlockAsync(BrainBlock brainBlock)
    {
        _ctx.Entry(brainBlock).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteBrainBlockAsync(BrainBlock brainBlock)
    {
        _ctx.BrainBlocks.Remove(brainBlock);
        await _ctx.SaveChangesAsync();
    }

    public async Task<List<BrainBlock>> GetBrainBlocksAsync()
    {
        return await _ctx.BrainBlocks.AsNoTracking().ToListAsync();
    }

    public async Task<List<BrainBlock>> GetBrainBlocksWithRelationsAsync(
        bool includeCategory = true,
        bool includeSubject = true,
        bool includeTopics = true,
        bool includeTags = true
    )
    {
        var q = _ctx.BrainBlocks.AsQueryable();

        if (includeCategory)
        {
            q = q.Include(qq => qq.Category);
        }

        if (includeSubject)
        {
            q = q.Include(qq => qq.Subject);
        }

        if (includeTopics)
        {
            q = q.Include(qq => qq.BrainBlockTopics).ThenInclude(bt => bt.Topic);
        }

        if (includeTags)
        {
            q = q.Include(qq => qq.BrainBlockTags).ThenInclude(bt => bt.Tag);
        }

        return await q.ToListAsync();
    }

    public async Task<BrainBlock?> GetBrainBlockAsync(int id)
    {
        return await _ctx.BrainBlocks.AsNoTracking().SingleOrDefaultAsync(q => q.Id == id);
    }
}
