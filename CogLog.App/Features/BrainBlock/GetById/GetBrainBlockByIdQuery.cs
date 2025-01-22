using MediatR;

namespace CogLog.App.Features.BrainBlock.GetById;

public record GetBrainBlockByIdQuery(int Id) : IRequest<BrainBlockDetailsDto>;
