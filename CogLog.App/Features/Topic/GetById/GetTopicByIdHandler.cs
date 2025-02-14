using AutoMapper;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Features.Topic.Get;
using MediatR;

namespace CogLog.App.Features.Topic.GetById;

public class GetTopicByIdHandler(IMapper mapper, ITopicRepo topicRepo)
    : IRequestHandler<GetTopicByIdQuery, TopicDto>
{
    public async Task<TopicDto> Handle(
        GetTopicByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var topic = await topicRepo.GetByIdAsync(request.Id);

        if (topic == null)
        {
            throw new NotFoundException(nameof(Topic), request.Id);
        }

        return mapper.Map<TopicDto>(topic);
    }
}
