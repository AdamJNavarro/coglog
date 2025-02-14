using MediatR;

namespace CogLog.App.Features.Topic.Delete;

public record DeleteTopicCommand(int Id) : IRequest<Unit>;
