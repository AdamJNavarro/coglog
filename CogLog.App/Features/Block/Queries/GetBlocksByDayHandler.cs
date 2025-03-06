using CogLog.App.Contracts.Data.Block;
using CogLog.App.Contracts.Persistence;
using MediatR;

namespace CogLog.App.Features.Block.Queries;

public class GetBlocksByDayHandler(IBlockRepo repo)
    : IRequestHandler<GetBlocksByDayQuery, List<BlocksByDayDto>>
{
    public async Task<List<BlocksByDayDto>> Handle(
        GetBlocksByDayQuery request,
        CancellationToken cancellationToken
    )
    {
        return await repo.GetBlocksByDayAsync();
    }
}
