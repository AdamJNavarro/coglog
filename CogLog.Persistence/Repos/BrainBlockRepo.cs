using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class BrainBlockRepo : GenericRepo<BrainBlock>, IBrainBlockRepo
{
    private readonly AppDbContext _context;

    public BrainBlockRepo(AppDbContext dbContext)
        : base(dbContext)
    {
        _context = dbContext;
    }

    public async Task<List<BrainBlock>> GetBrainBlocksWithDetails()
    {
        var brainBlocks = await _context.BrainBlocks.ToListAsync();

        return brainBlocks;
    }
}
