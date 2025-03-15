using CogLog.App.Contracts.Data.Topic;
using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface ITopicRepo : IBaseRepo<Topic>
{
    Task CreateTopicAsync(Topic topic);
    Task UpdateTopicAsync(Topic topic);
    Task DeleteTopicAsync(int id);
    Task<TopicDetailsDto?> GetTopicDetailsAsync(int id);
    Task<List<TopicMinimalDto>> GetAllTopicsAsync(int? subjectId = null);
}
