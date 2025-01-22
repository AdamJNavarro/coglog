using MediatR;

namespace CogLog.App.Features.BrainBlock.Get;

public record GetBrainBlocksQuery : IRequest<List<BrainBlockDto>>;
