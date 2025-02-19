using MediatR;

namespace CogLog.App.Features.Block.Commands;

public record DeleteBlockCommand(int Id) : IRequest<Unit>;
