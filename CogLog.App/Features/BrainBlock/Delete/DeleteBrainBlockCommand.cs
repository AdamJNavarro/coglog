using MediatR;

namespace CogLog.App.Features.BrainBlock.Delete;

public record DeleteBrainBlockCommand(int Id) : IRequest<Unit>;
