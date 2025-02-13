using MediatR;

namespace CogLog.App.Features.Topic.Create;

public record CreateTopicCommand(string Title, string? Logo) : IRequest<int>;
