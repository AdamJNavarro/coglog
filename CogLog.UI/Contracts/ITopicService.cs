using CogLog.UI.Models.Topic;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface ITopicService
{
    // Task<List<TopicVm>> GetTopicsAsync();
    //
    // Task<TopicVm> GetTopicAsync(int id);

    Task<Response<Guid>> CreateTopicAsync(CreateTopicVm topic);

    Task<Response<Guid>> EditTopicAsync(int id, TopicVm topic);

    Task<Response<Guid>> DeleteTopicAsync(int id);
}
