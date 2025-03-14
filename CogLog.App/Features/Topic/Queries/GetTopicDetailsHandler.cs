using CogLog.App.Contracts.Data.Topic;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Topic.Queries;

public class GetTopicDetailsHandler(ITopicRepo repo)
    : IRequestHandler<GetTopicDetailsQuery, TopicDetailsDto>
{
    public async Task<TopicDetailsDto> Handle(
        GetTopicDetailsQuery request,
        CancellationToken cancellationToken
    )
    {
        var topic = await repo.GetTopicDetailsAsync(request.Id);

        if (topic is null)
        {
            throw new NotFoundException(nameof(Topic), request.Id);
        }

        return topic;
    }
}
