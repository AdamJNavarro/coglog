using MediatR;

namespace Vonavulary.App.Features.Word.Commands;

public record DeleteWordCommand(int Id) : IRequest<Unit>;
