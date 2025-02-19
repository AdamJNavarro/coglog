using MediatR;

namespace CogLog.App.Features.Topic.Commands;

public record CreateTopicCommand(string Label, string? Icon, string? Description, int SubjectId)
    : IRequest<int>;
