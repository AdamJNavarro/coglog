using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Tag.Commands;

public class CreateTagHandler(ITagRepo tagRepo, ISubjectRepo subjectRepo)
    : IRequestHandler<CreateTagCommand, int>
{
    public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTagValidator(subjectRepo);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Tag", validationResult);
        }

        var incomingTag = request.ToTag();
        await tagRepo.CreateTagAsync(incomingTag);
        return incomingTag.Id;
    }
}
