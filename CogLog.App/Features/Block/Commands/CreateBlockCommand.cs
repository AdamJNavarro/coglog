using MediatR;

namespace CogLog.App.Features.Block.Commands;

public record CreateBlockCommand(
    string Title,
    string Content,
    string? ExtraContent,
    string? Url,
    int? CategoryId,
    int? SubjectId,
    List<int> TopicIds
) : IRequest<int>;
