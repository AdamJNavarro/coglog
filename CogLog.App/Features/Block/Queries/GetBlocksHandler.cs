using CogLog.App.Contracts.Data.Block;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Models.Pagination;
using MediatR;

namespace CogLog.App.Features.Block.Queries;

public class GetBlocksHandler(IBlockRepo repo)
    : IRequestHandler<GetBlocksQuery, PaginationResponse<BlockDto>>
{
    public async Task<PaginationResponse<BlockDto>> Handle(
        GetBlocksQuery request,
        CancellationToken cancellationToken
    )
    {
        var data = await repo.GetBlocksAsync(request.Parameters);
        return data;
    }
}
