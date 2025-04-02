using CogLog.App.Contracts.Data.Word;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using CogLog.App.Models.Pagination;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class WordRepo(AppDbContext ctx) : BaseRepo<Word>(ctx), IWordRepo
{
    private readonly AppDbContext _ctx = ctx;

    public async Task CreateWordAsync(Word word)
    {
        await _ctx.Words.AddAsync(word);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateWordAsync(Word word)
    {
        _ctx.Entry(word).State = EntityState.Modified;
        _ctx.Entry(word).Property(x => x.CreatedAt).IsModified = false;
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteWordAsync(Word word)
    {
        _ctx.Words.Remove(word);
        await _ctx.SaveChangesAsync();
    }

    public async Task<PaginationResponse<WordDto>> GetWordsAsync(WordsQueryParameters parameters)
    {
        // Validate parameters
        if (parameters.Page < 1)
            parameters.Page = 1;
        if (parameters.PerPage < 1)
            parameters.PerPage = 10;

        var query = _ctx.Words.AsNoTracking();

        query = ApplyFilters(query, parameters);

        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)parameters.PerPage);

        var words = await query
            .Skip((parameters.Page - 1) * parameters.PerPage)
            .Take(parameters.PerPage)
            .OrderByDescending(b => b.LearnedAt.Date)
            .ToListAsync();

        var paginationMetadata = new PaginationMetadata()
        {
            TotalItems = totalItems,
            TotalPages = totalPages,
            Page = parameters.Page,
            PerPage = parameters.PerPage,
        };

        return new PaginationResponse<WordDto>()
        {
            Pagination = paginationMetadata,
            Data = words.ToWordDtoList(),
        };
    }

    private static IQueryable<Word> ApplyFilters(
        IQueryable<Word> query,
        WordsQueryParameters parameters
    )
    {
        if (!string.IsNullOrWhiteSpace(parameters.Search))
        {
            query = query.Where(p => p.Spelling.Contains(parameters.Search));
        }

        return query;
    }
}
