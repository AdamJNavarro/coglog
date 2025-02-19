using MediatR;

namespace CogLog.App.Features.Topic.Commands;

public record DeleteTopicCommand(int Id) : IRequest<Unit>;
