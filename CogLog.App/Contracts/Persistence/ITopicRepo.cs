using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface ITopicRepo : IBaseRepo<Topic>
{
    Task<List<Topic>> GetTopicsBySubjectAsync(int subjectId);
    Task CreateTopicAsync(Topic topic);
    Task UpdateTopicAsync(Topic topic);
    Task DeleteTopicAsync(Topic topic);

    Task<Topic?> GetTopicAsync(int id);
}
