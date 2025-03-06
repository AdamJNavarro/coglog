using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface ITagRepo : IBaseRepo<Tag>
{
    Task CreateTagAsync(Tag tag);
    Task UpdateTagAsync(Tag tag);
    Task DeleteTagAsync(Tag tag);
    Task<Tag?> GetTagAsync(int id);
    Task<List<Tag>> GetTagsBySubjectAsync(int subjectId);
}
