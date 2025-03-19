using MediatR;

namespace CogLog.App.Features.Block.Commands;

public record UpdateBlockCommand(
    int Id,
    string Title,
    string Content,
    string? ExtraContent,
    string? Url,
    int? SubjectId,
    List<int> TopicIds,
    List<int> TagIds
) : IRequest<Unit>;
