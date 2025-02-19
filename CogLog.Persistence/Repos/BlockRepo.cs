using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class BlockRepo(AppDbContext ctx) : BaseRepo<Block>(ctx), IBlockRepo
{
    private readonly AppDbContext _ctx = ctx;

    public async Task CreateBlockAsync(Block block)
    {
        await _ctx.Blocks.AddAsync(block);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateBlockAsync(Block block)
    {
        _ctx.Entry(block).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteBlockAsync(Block block)
    {
        _ctx.Blocks.Remove(block);
        await _ctx.SaveChangesAsync();
    }

    public async Task<List<Block>> GetBlocksAsync()
    {
        return await _ctx.Blocks.AsNoTracking().ToListAsync();
    }

    public async Task<List<Block>> GetBlocksWithRelationsAsync(
        bool includeCategory = true,
        bool includeSubject = true,
        bool includeTopics = true,
        bool includeTags = true
    )
    {
        var q = _ctx.Blocks.AsQueryable();

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
            q = q.Include(qq => qq.BlockTopics).ThenInclude(bt => bt.Topic);
        }

        if (includeTags)
        {
            q = q.Include(qq => qq.BlockTags).ThenInclude(bt => bt.Tag);
        }

        return await q.ToListAsync();
    }

    public async Task<Block?> GetBlockAsync(int id)
    {
        return await _ctx.Blocks.AsNoTracking().SingleOrDefaultAsync(q => q.Id == id);
    }
}
