using AutoMapper;
using CogLog.App.Contracts.Persistence;
using MediatR;

namespace CogLog.App.Features.Topic.Get;

public class GetTopicsHandler(IMapper mapper, ITopicRepo topicRepo)
    : IRequestHandler<GetTopicsQuery, List<TopicDto>>
{
    public async Task<List<TopicDto>> Handle(
        GetTopicsQuery request,
        CancellationToken cancellationToken
    )
    {
        var topics = await topicRepo.GetAsync();
        var data = mapper.Map<List<TopicDto>>(topics);
        return data;
    }
}
