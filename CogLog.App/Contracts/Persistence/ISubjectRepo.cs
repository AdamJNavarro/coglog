using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface ISubjectRepo : IBaseRepo<Subject>
{
    Task CreateSubjectAsync(Subject subject);
    Task<List<Subject>> GetSubjectsAsync();

    Task<Subject> GetSubjectWithRelationsAsync(
        int id,
        bool includeCategory,
        bool includeTopics,
        bool includeTags,
        bool includeBlocks
    );
    Task UpdateSubjectAsync(Subject subject);
    Task DeleteSubjectAsync(Subject subject);
}
