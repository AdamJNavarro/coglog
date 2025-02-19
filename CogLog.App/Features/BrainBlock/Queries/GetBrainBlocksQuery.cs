using CogLog.App.Contracts.Data;
using MediatR;

namespace CogLog.App.Features.BrainBlock.Queries;

public record GetBrainBlocksQuery : IRequest<List<BrainBlockDto>>;
