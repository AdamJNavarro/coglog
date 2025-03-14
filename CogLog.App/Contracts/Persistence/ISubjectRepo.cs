using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Models.Pagination;
using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface ISubjectRepo : IBaseRepo<Subject>
{
    Task<List<SubjectMinimalDto>> GetAllSubjectsAsync(int? categoryId);
    Task<PaginationResponse<SubjectPaginatedDto>> GetPaginatedSubjectsAsync(
        SubjectQueryParameters parameters
    );
    Task<SubjectDetailsDto?> GetSubjectDetailsAsync(int id);

    Task CreateSubjectAsync(Subject subject);
    Task UpdateSubjectAsync(Subject subject);
    Task DeleteSubjectAsync(int id);
}
