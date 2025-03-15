using CogLog.UI.Models.Topic;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Contracts;

public interface ITopicService
{
    Task<List<TopicMinimalVm>> GetTopicsAsync();

    Task<TopicDetailsVm> GetTopicDetailsAsync(int id);

    Task<List<SelectListItem>> GetSelectListAsync(int? subjectId = null);

    Task<Response<Guid>> CreateTopicAsync(TopicCreateVm topic);

    Task<Response<Guid>> EditTopicAsync(TopicEditVm topic);

    Task<Response<Guid>> DeleteTopicAsync(int id);
}
