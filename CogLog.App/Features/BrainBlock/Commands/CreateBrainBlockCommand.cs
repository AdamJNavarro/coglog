using MediatR;

namespace CogLog.App.Features.BrainBlock.Commands;

public record CreateBrainBlockCommand(
    string Title,
    string Content,
    string? ExtraContent,
    string? Url,
    int? CategoryId,
    int? SubjectId,
    List<int> TopicIds
) : IRequest<int>;
