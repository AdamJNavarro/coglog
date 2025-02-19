using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.BrainBlock.Commands;

public class DeleteBrainBlockHandler(IBrainBlockRepo brainBlockRepo)
    : IRequestHandler<DeleteBrainBlockCommand, Unit>
{
    public async Task<Unit> Handle(
        DeleteBrainBlockCommand request,
        CancellationToken cancellationToken
    )
    {
        var blockToDelete = await brainBlockRepo.GetBrainBlockAsync(request.Id);

        if (blockToDelete == null)
        {
            throw new NotFoundException(nameof(BrainBlock), request.Id);
        }

        await brainBlockRepo.DeleteBrainBlockAsync(blockToDelete);

        return Unit.Value;
    }
}
