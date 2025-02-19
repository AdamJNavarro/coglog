using AutoMapper;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.Topic.Commands;

public class UpdateTopicHandler(ITopicRepo topicRepo) : IRequestHandler<UpdateTopicCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var existingTopic = await topicRepo.GetTopicAsync(request.Id);

        if (existingTopic is null)
        {
            throw new NotFoundException(nameof(Topic), request.Id);
        }

        await topicRepo.UpdateTopicAsync(existingTopic);

        return Unit.Value;
    }
}
