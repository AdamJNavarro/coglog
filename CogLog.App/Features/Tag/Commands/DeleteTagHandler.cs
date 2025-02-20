using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.Tag.Commands;

public class DeleteTagHandler(ITagRepo tagRepo) : IRequestHandler<DeleteTagCommand, Unit>
{
    public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var tagToDelete = await tagRepo.GetTagAsync(request.Id);

        if (tagToDelete == null)
        {
            throw new NotFoundException(nameof(Tag), request.Id);
        }
        await tagRepo.DeleteTagAsync(tagToDelete);
        return Unit.Value;
    }
}
