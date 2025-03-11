using CogLog.App.Contracts.Data.Topic;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Topic.Queries;

public class GetTopicHandler(ITopicRepo repo) : IRequestHandler<GetTopicQuery, TopicDto>
{
    public async Task<TopicDto> Handle(GetTopicQuery request, CancellationToken cancellationToken)
    {
        var topic = await repo.GetTopicAsync(request.Id);

        if (topic is null)
        {
            throw new NotFoundException(nameof(Topic), request.Id);
        }

        return topic.ToTopicDto();
    }
}
