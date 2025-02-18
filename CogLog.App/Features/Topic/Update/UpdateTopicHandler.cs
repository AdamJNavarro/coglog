using AutoMapper;
using CogLog.App.Contracts.Persistence;
using MediatR;

namespace CogLog.App.Features.Topic.Update;

public class UpdateTopicHandler(IMapper mapper, ITopicRepo topicRepo)
    : IRequestHandler<UpdateTopicCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var topicToUpdate = mapper.Map<Domain.Topic>(request);

        await topicRepo.UpdateAsync(topicToUpdate);

        return Unit.Value;
    }
}
