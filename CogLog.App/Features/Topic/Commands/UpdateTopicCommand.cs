using MediatR;

namespace CogLog.App.Features.Topic.Commands;

public record UpdateTopicCommand(
    int Id,
    string Name,
    string? Icon,
    string? Description,
    int SubjectId
) : IRequest<Unit>;
