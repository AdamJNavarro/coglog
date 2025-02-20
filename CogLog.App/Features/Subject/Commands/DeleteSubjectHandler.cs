using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.Subject.Commands;

public class DeleteSubjectHandler(ISubjectRepo repo) : IRequestHandler<DeleteSubjectCommand, Unit>
{
    public async Task<Unit> Handle(
        DeleteSubjectCommand request,
        CancellationToken cancellationToken
    )
    {
        var subjectToDelete = await repo.GetSubjectWithRelationsAsync(
            request.Id,
            false,
            false,
            false,
            true
        );
        if (subjectToDelete == null)
        {
            throw new NotFoundException(nameof(Subject), request.Id);
        }
        await repo.DeleteSubjectAsync(subjectToDelete);
        return Unit.Value;
    }
}
