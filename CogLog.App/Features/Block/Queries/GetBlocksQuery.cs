using CogLog.App.Contracts.Data.Block;
using CogLog.App.Models.Pagination;
using MediatR;

namespace CogLog.App.Features.Block.Queries;

public record GetBlocksQuery(BlocksQueryParameters Parameters)
    : IRequest<PaginationResponse<BlockDto>>;
