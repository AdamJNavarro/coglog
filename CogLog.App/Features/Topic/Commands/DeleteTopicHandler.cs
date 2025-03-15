using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.Topic.Commands;

public class DeleteTopicHandler(ITopicRepo topicRepo) : IRequestHandler<DeleteTopicCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        await topicRepo.DeleteTopicAsync(request.Id);

        return Unit.Value;
    }
}
