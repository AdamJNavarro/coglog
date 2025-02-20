using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Tag.Commands;

public class UpdateTagHandler(ITagRepo repo) : IRequestHandler<UpdateTagCommand, Unit>
{
    public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var tagExists = await repo.EntityExistsAsync(request.Id);
        if (tagExists == false)
        {
            throw new NotFoundException(nameof(Tag), request.Id);
        }

        var tag = request.ToTag();
        await repo.UpdateTagAsync(tag);
        return Unit.Value;
    }
}
