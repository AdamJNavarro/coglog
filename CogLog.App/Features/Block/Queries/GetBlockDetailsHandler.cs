using CogLog.App.Contracts.Data.Block;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.Block.Queries;

public class GetBlockDetailsHandler(IBlockRepo blockRepo)
    : IRequestHandler<GetBlockDetailsQuery, BlockDetailsDto>
{
    public async Task<BlockDetailsDto> Handle(
        GetBlockDetailsQuery request,
        CancellationToken cancellationToken
    )
    {
        var block = await blockRepo.GetBlockDetailsAsync(request.Id);

        if (block is null)
        {
            throw new NotFoundException(nameof(Block), request.Id);
        }

        return block;
    }
}
