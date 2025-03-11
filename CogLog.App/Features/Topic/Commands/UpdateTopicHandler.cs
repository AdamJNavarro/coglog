using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Topic.Commands;

public class UpdateTopicHandler(ITopicRepo topicRepo, ISubjectRepo subjectRepo)
    : IRequestHandler<UpdateTopicCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateTopicValidator(topicRepo, subjectRepo);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Topic", validationResult);
        }

        await topicRepo.UpdateTopicAsync(request.ToTopic());

        return Unit.Value;
    }
}
