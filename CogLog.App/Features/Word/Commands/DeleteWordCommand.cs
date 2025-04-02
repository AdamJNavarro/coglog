using MediatR;

namespace CogLog.App.Features.Word.Commands;

public record DeleteWordCommand(int Id) : IRequest<Unit>;
