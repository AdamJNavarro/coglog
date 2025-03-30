using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using CogLog.App.Models.Pagination;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class SubjectRepo(AppDbContext ctx) : BaseRepo<Subject>(ctx), ISubjectRepo
{
    private readonly AppDbContext _ctx = ctx;

    public async Task<SubjectDetailsDto?> GetSubjectDetailsAsync(int id)
    {
        var subject = await _ctx
            .Subjects.Include(x => x.Category)
            .Include(x => x.Topics)
            .Include(x => x.Tags)
            .SingleOrDefaultAsync(x => x.Id == id);
        return subject.ToSubjectDetailsDto();
    }

    public async Task<List<SubjectMinimalDto>> GetAllSubjectsAsync(int? categoryId)
    {
        var query = _ctx.Subjects.AsNoTracking();

        query = query.OrderBy(q => q.Name);

        if (categoryId.HasValue)
        {
            query = query.Where(x => x.CategoryId == categoryId.Value);
        }

        var subjects = await query.ToListAsync();

        return subjects.ToSubjectMinimalDtoList();
    }

    public async Task<PaginationResponse<SubjectPaginatedDto>> GetPaginatedSubjectsAsync(
        SubjectQueryParameters parameters
    )
    {
        if (parameters.Page < 1)
            parameters.Page = 1;
        if (parameters.PerPage < 1)
            parameters.PerPage = 10;

        var query = _ctx.Subjects.AsNoTracking();

        query = ApplyFilters(query, parameters);

        query = query.OrderBy(q => q.Name);

        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)parameters.PerPage);

        var subjects = await query
            .Include(x => x.Category)
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

        return new PaginationResponse<SubjectPaginatedDto>
        {
            Pagination = paginationMetadata,
            Data = subjects.ToSubjectPaginatedDtoList(),
        };
    }

    private IQueryable<Subject> ApplyFilters(
        IQueryable<Subject> query,
        SubjectQueryParameters parameters
    )
    {
        if (!string.IsNullOrWhiteSpace(parameters.Category))
        {
            query = query.Where(p => p.Category.Name.Contains(parameters.Category));
        }

        if (!string.IsNullOrWhiteSpace(parameters.Name))
        {
            query = query.Where(p => p.Name.Contains(parameters.Name));
        }

        return query;
    }

    public async Task CreateSubjectAsync(Subject subject)
    {
        await _ctx.Subjects.AddAsync(subject);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateSubjectAsync(Subject subject)
    {
        _ctx.Entry(subject).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
    }

    public async Task DeleteSubjectAsync(int id)
    {
        await using var transaction = await _ctx.Database.BeginTransactionAsync();

        try
        {
            // Update all Blocks to have null SubjectId
            await _ctx
                .Blocks.Where(p => p.SubjectId == id)
                .ExecuteUpdateAsync(p => p.SetProperty(x => x.SubjectId, (int?)null));

            // Delete the subject
            var subject = await _ctx.Subjects.FindAsync(id);
            if (subject != null)
            {
                _ctx.Subjects.Remove(subject);
            }

            await _ctx.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
