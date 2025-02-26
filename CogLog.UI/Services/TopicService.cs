using AutoMapper;
using CogLog.UI.Contracts;
using CogLog.UI.Models;
using CogLog.UI.Models.Topic;
using CogLog.UI.Services.Base;
using Exception = System.Exception;

namespace CogLog.UI.Services;

public class TopicService(IClient client, IMapper mapper, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        ITopicService
{
    private readonly IClient _client = client;

    public async Task<List<TopicVm>> GetTopicsAsync()
    {
        AddBearerToken();
        var topics = await _client.TopicAllAsync();
        return mapper.Map<List<TopicVm>>(topics);
    }

    public async Task<TopicVm> GetTopicAsync(int id)
    {
        var topic = await _client.TopicGETAsync(id);
        return mapper.Map<TopicVm>(topic);
    }

    public async Task<Response<Guid>> CreateTopicAsync(CreateTopicVm topic)
    {
        try
        {
            AddBearerToken();

            var createTopicCommand = mapper.Map<CreateTopicCommand>(topic);
            await _client.TopicPOSTAsync(createTopicCommand);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> EditTopicAsync(int id, TopicVm topic)
    {
        try
        {
            var updateCommand = mapper.Map<UpdateTopicCommand>(topic);
            await _client.TopicPUTAsync(id.ToString(), updateCommand);
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
            await _client.TopicDELETEAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
