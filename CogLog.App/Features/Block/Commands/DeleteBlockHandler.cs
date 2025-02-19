using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.Block.Commands;

public class DeleteBlockHandler(IBlockRepo blockRepo) : IRequestHandler<DeleteBlockCommand, Unit>
{
    public async Task<Unit> Handle(DeleteBlockCommand request, CancellationToken cancellationToken)
    {
        var blockToDelete = await blockRepo.GetBlockAsync(request.Id);

        if (blockToDelete == null)
        {
            throw new NotFoundException(nameof(Block), request.Id);
        }

        await blockRepo.DeleteBlockAsync(blockToDelete);

        return Unit.Value;
    }
}
