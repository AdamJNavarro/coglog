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
        var validator = new CreateTopicValidator(subjectRepo);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Topic", validationResult);
        }

        var incomingTopic = request.ToTopic();
        await topicRepo.CreateTopicAsync(incomingTopic);

        return incomingTopic.Id;
    }
}
