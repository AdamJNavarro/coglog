using CogLog.UI.Contracts;
using CogLog.UI.Mapping;
using CogLog.UI.Models.Topic;
using CogLog.UI.Services.Base;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CogLog.UI.Services;

public class TopicService(IClient client, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        ITopicService
{
    private readonly IClient _client = client;

    public async Task<List<TopicMinimalVm>> GetTopicsAsync()
    {
        var data = await _client.TopicsGetAllAsync(null);
        return data.ToTopicMinimalVmList();
    }

    public async Task<TopicDetailsVm> GetTopicDetailsAsync(int id)
    {
        var topic = await _client.TopicGetDetailsAsync(id);
        return topic.ToTopicDetailsVm();
    }

    public async Task<List<SelectListItem>> GetSelectListAsync(int? subjectId = null)
    {
        var topics = await _client.TopicsGetAllAsync(subjectId);

        return topics
            .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
            .ToList();
    }

    public async Task<Response<Guid>> CreateTopicAsync(TopicCreateVm topic)
    {
        try
        {
            // AddBearerToken();

            var cmd = topic.ToCreateTopicCommand();
            await _client.TopicCreateAsync(cmd);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> EditTopicAsync(TopicEditVm topic)
    {
        try
        {
            var updateCommand = topic.ToUpdateTopicCommand();
            await _client.TopicUpdateAsync(topic.Id.ToString(), updateCommand);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteTopicAsync(int id)
    {
        try
        {
            await _client.TopicDeleteAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
