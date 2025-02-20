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
        var subjectExists = await subjectRepo.EntityExistsAsync(request.Id);
        if (subjectExists == false)
        {
            throw new NotFoundException(nameof(Subject), request.Id);
        }

        // if updating categoryId, check for category existence
        var updatedSubject = request.ToSubject();
        await subjectRepo.UpdateSubjectAsync(updatedSubject);

        return Unit.Value;
    }
}
