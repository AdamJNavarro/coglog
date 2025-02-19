using MediatR;

namespace CogLog.App.Features.Topic.Commands;

public record UpdateTopicCommand(int Id, string Label, string? Icon, string? Description)
    : IRequest<Unit>;
