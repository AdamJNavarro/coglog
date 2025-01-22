using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.BrainBlock.Delete;

public class DeleteBrainBlockHandler(IBrainBlockRepo brainBlockRepo)
    : IRequestHandler<DeleteBrainBlockCommand, Unit>
{
    public async Task<Unit> Handle(
        DeleteBrainBlockCommand request,
        CancellationToken cancellationToken
    )
    {
        var blockToDelete = await brainBlockRepo.GetByIdAsync(request.Id);

        if (blockToDelete == null)
        {
            throw new NotFoundException(nameof(BrainBlock), request.Id);
        }

        await brainBlockRepo.DeleteAsync(blockToDelete);

        return Unit.Value;
    }
}
