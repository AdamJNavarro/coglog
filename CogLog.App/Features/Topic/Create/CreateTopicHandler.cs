using AutoMapper;
using CogLog.App.Contracts.Persistence;
using MediatR;

namespace CogLog.App.Features.Topic.Create;

public class CreateTopicHandler(IMapper mapper, ITopicRepo topicRepo)
    : IRequestHandler<CreateTopicCommand, int>
{
    public async Task<int> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var incomingTopic = mapper.Map<Domain.Topic>(request);

        await topicRepo.CreateAsync(incomingTopic);

        return incomingTopic.Id;
    }
}
