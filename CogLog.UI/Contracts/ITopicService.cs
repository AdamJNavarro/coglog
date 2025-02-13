using CogLog.UI.Models;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface ITopicService
{
    Task<List<TopicVm>> GetTopics();

    Task<TopicVm> GetTopicById(int id);

    Task<Response<Guid>> CreateTopic(CreateTopicVm topic);

    Task<Response<Guid>> EditTopic(int id, TopicVm topic);

    Task<Response<Guid>> DeleteTopic(int id);
}
