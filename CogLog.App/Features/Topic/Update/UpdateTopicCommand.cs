using MediatR;

namespace CogLog.App.Features.Topic.Update;

public record UpdateTopicCommand(int Id, string Title, string? Logo) : IRequest<Unit>;
