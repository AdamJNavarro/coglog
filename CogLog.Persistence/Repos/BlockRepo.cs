using CogLog.App.Contracts.Data.Block;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using CogLog.App.Models.Pagination;
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
        // _ctx.Entry(block).State = EntityState.Modified;
        _ctx.Blocks.Update(block);
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteBlockAsync(Block block)
    {
        _ctx.Blocks.Remove(block);
        await _ctx.SaveChangesAsync();
    }

    public async Task<List<BlocksByDayDto>> GetBlocksByDayAsync()
    {
        var blocks = await _ctx.Blocks.AsNoTracking().ToListAsync();

        var blocksByDay = blocks
            .GroupBy(b => b.LearnedAt.Date)
            .Select(group => new BlocksByDayDto(
                (DateTime)group.Key!,
                group.Count(),
                group.ToList().Select(x => x.ToBlockDto()).ToList()
            ))
            .OrderByDescending(b => b.Day)
            .ToList();
        return blocksByDay;
    }

    public async Task<Block?> GetBlockAsync(
        int id,
        bool includeTopics = false,
        bool includeTags = false
    )
    {
        var query = _ctx.Blocks.AsNoTracking();
        if (includeTopics)
        {
            query = query.Include(q => q.BlockTopics);
        }

        if (includeTags)
        {
            query = query.Include(q => q.BlockTags);
        }

        return await query.SingleOrDefaultAsync(q => q.Id == id);
    }

    public async Task<BlockDetailsDto?> GetBlockDetailsAsync(int id)
    {
        var block = await _ctx
            .Blocks.Include(b => b.Subject)
            .Include(b => b.BlockTopics)
            .ThenInclude(bt => bt.Topic)
            .Include(b => b.BlockTags)
            .ThenInclude(bt => bt.Tag)
            .SingleOrDefaultAsync(q => q.Id == id);
        return block.ToBlockDetailsDto();
    }

    public async Task<PaginationResponse<BlockDto>> GetBlocksAsync(BlocksQueryParameters parameters)
    {
        // Validate parameters
        if (parameters.Page < 1)
            parameters.Page = 1;
        if (parameters.PerPage < 1)
            parameters.PerPage = 10;

        var query = _ctx.Blocks.AsNoTracking();

        query = ApplyFilters(query, parameters);

        // Get total count for pagination
        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)parameters.PerPage);

        var blocks = await query
            .Include(b => b.Subject)
            .Include(b => b.BlockTopics)
            .ThenInclude(bt => bt.Topic)
            .Include(b => b.BlockTags)
            .ThenInclude(bt => bt.Tag)
            .Skip((parameters.Page - 1) * parameters.PerPage)
            .Take(parameters.PerPage)
            .ToListAsync();

        var paginationMetadata = new PaginationMetadata
        {
            TotalItems = totalItems,
            TotalPages = totalPages,
            Page = parameters.Page,
            PerPage = parameters.PerPage,
        };

        return new PaginationResponse<BlockDto>
        {
            Pagination = paginationMetadata,
            Data = blocks.ToBlockDtoList(),
        };
    }

    private IQueryable<Block> ApplyFilters(
        IQueryable<Block> query,
        BlocksQueryParameters parameters
    )
    {
        // if (!string.IsNullOrWhiteSpace(parameters.CategoryName))
        // {
        //     query = query.Where(p =>
        //         p.Category != null && p.Category.Name.Contains(parameters.CategoryName)
        //     );
        // }

        if (!string.IsNullOrWhiteSpace(parameters.SubjectName))
        {
            query = query.Where(p =>
                p.Subject != null && p.Subject.Name.Contains(parameters.SubjectName)
            );
        }

        if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
        {
            query = query.Where(p => p.Title.Contains(parameters.SearchTerm));
        }

        // Apply tag filtering
        // if (parameters.TagIds != null && parameters.TagIds.Any())
        // {
        //     query = query.Where(b => b.BlockTags.Any(bt => parameters.TagIds.Contains(bt.TagId)));
        // }

        // Filter by tag names if provided
        // if (!string.IsNullOrWhiteSpace(parameters.TagNames))
        // {
        //     var tagNames = parameters
        //         .TagNames.Split(',')
        //         .Select(t => t.Trim())
        //         .Where(t => !string.IsNullOrWhiteSpace(t))
        //         .ToList();
        //
        //     if (tagNames.Any())
        //     {
        //         query = query.Where(b => b.BlockTags.Any(pt => tagNames.Contains(pt.Tag.Label)));
        //     }
        // }

        return query;
    }

    // private IQueryable<Block> ApplySorting(
    //     IQueryable<Block> query,
    //     BlocksQueryParameters parameters
    // )
    // {
    //     // Default sort by date descending if not specified
    //     if (string.IsNullOrWhiteSpace(parameters.SortBy))
    //     {
    //         parameters.SortBy = "DateAdded";
    //         parameters.SortDescending = true;
    //     }
    //
    //     // Apply sorting based on the specified field
    //     switch (parameters.SortBy.ToLower())
    //     {
    //         default:
    //             query = parameters.SortDescending
    //                 ? query.OrderByDescending(p => p.DateAdded)
    //                 : query.OrderBy(p => p.DateAdded);
    //             break;
    //     }
    //
    //     return query;
    // }
}
