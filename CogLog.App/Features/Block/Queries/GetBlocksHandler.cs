using CogLog.App.Contracts.Data.Block;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Block.Queries;

public class GetBlocksHandler(IBlockRepo repo) : IRequestHandler<GetBlocksQuery, List<BlockDto>>
{
    public async Task<List<BlockDto>> Handle(
        GetBlocksQuery request,
        CancellationToken cancellationToken
    )
    {
        var blocks = await repo.GetBlocksWithRelationsAsync(true, true, true, true);
        return blocks.ToBlocksDto();
    }
}
