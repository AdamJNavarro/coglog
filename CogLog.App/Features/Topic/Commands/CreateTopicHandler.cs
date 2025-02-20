using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Topic.Commands;

public class CreateTopicHandler(ITopicRepo topicRepo, ISubjectRepo subjectRepo)
    : IRequestHandler<CreateTopicCommand, int>
{
    public async Task<int> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var subjectExists = await subjectRepo.EntityExistsAsync(request.SubjectId);

        if (!subjectExists)
        {
            throw new NotFoundException(nameof(Subject), request.SubjectId);
        }

        var incomingTopic = request.ToTopic();
        await topicRepo.CreateTopicAsync(incomingTopic);

        return incomingTopic.Id;
    }
}
