using CogLog.App.Contracts.Data.Block;
using MediatR;

namespace CogLog.App.Features.Block.Queries;

public record GetBlocksQuery : IRequest<List<BlockDto>>;
