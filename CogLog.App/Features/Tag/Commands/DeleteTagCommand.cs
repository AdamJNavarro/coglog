using MediatR;

namespace CogLog.App.Features.Tag.Commands;

public record DeleteTagCommand(int Id) : IRequest<Unit>;
