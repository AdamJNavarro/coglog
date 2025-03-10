using MediatR;

namespace CogLog.App.Features.Tag.Commands;

public record UpdateTagCommand(
    int Id,
    string Name,
    string? Icon,
    string? Description,
    int SubjectId
) : IRequest<Unit>;
