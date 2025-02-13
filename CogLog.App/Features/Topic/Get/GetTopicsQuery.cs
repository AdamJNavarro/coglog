using MediatR;

namespace CogLog.App.Features.Topic.Get;

public record GetTopicsQuery : IRequest<List<TopicDto>>;
