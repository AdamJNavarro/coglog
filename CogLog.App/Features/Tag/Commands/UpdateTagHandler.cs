using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Tag.Commands;

public class UpdateTagHandler(ITagRepo tagRepo, ISubjectRepo subjectRepo)
    : IRequestHandler<UpdateTagCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateTagValidator(tagRepo, subjectRepo);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Tag", validationResult);
        }

        await tagRepo.UpdateTagAsync(request.ToTag());
        return Unit.Value;
    }
}
