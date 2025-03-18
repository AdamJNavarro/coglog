using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.Topic.Commands;

public class DeleteTopicHandler(ITopicRepo topicRepo) : IRequestHandler<DeleteTopicCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = await topicRepo.GetEntityAsync(request.Id);

        if (topic == null)
        {
            throw new NotFoundException(nameof(Topic), request.Id);
        }

        await topicRepo.DeleteTopicAsync(topic);

        return Unit.Value;
    }
}
