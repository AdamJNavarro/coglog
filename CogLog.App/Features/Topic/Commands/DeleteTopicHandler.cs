using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.Topic.Commands;

public class DeleteTopicHandler(ITopicRepo topicRepo) : IRequestHandler<DeleteTopicCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        var topicToDelete = await topicRepo.GetTopicAsync(request.Id);

        if (topicToDelete == null)
        {
            throw new NotFoundException(nameof(Topic), request.Id);
        }

        await topicRepo.DeleteTopicAsync(topicToDelete);

        return Unit.Value;
    }
}
