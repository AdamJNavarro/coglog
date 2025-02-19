using MediatR;

namespace CogLog.App.Features.BrainBlock.Commands;

public record DeleteBrainBlockCommand(int Id) : IRequest<Unit>;
