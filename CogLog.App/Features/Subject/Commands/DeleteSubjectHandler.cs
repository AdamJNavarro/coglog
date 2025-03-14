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
        await repo.DeleteSubjectAsync(request.Id);
        return Unit.Value;
    }
}
