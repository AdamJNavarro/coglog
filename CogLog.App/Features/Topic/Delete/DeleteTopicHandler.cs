using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Features.BrainBlock.Delete;
using MediatR;

namespace CogLog.App.Features.Topic.Delete;

public class DeleteTopicHandler(ITopicRepo topicRepo) : IRequestHandler<DeleteTopicCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
    {
        var topicToDelete = await topicRepo.GetByIdAsync(request.Id);

        if (topicToDelete == null)
        {
            throw new NotFoundException(nameof(Topic), request.Id);
        }

        await topicRepo.DeleteAsync(topicToDelete);

        return Unit.Value;
    }
}
