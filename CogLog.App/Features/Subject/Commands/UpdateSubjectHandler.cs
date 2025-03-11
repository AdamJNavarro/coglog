using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Subject.Commands;

public class UpdateSubjectHandler(ISubjectRepo subjectRepo, ICategoryRepo categoryRepo)
    : IRequestHandler<UpdateSubjectCommand, Unit>
{
    public async Task<Unit> Handle(
        UpdateSubjectCommand request,
        CancellationToken cancellationToken
    )
    {
        var validator = new UpdateSubjectValidator(subjectRepo, categoryRepo);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Subject", validationResult);
        }

        var updatedSubject = request.ToSubject();
        await subjectRepo.UpdateSubjectAsync(updatedSubject);

        return Unit.Value;
    }
}
