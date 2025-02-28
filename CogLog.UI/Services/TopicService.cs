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

    public async Task<Response<Guid>> CreateTopicAsync(CreateTopicVm topic)
    {
        try
        {
            AddBearerToken();

            var createTopicCommand = mapper.Map<CreateTopicCommand>(topic);
            await _client.TopicsPOSTAsync(createTopicCommand);
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
            await _client.TopicsPUTAsync(id.ToString(), updateCommand);
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
            await _client.TopicsDELETEAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
