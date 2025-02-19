using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.BrainBlock.Queries;

public class GetBrainBlocksHandler(IBrainBlockRepo repo)
    : IRequestHandler<GetBrainBlocksQuery, List<BrainBlockDto>>
{
    public async Task<List<BrainBlockDto>> Handle(
        GetBrainBlocksQuery request,
        CancellationToken cancellationToken
    )
    {
        var brainBlocks = await repo.GetBrainBlocksWithRelationsAsync(true, true, true, true);
        return brainBlocks.ToBrainBlocksDto();
    }
}
