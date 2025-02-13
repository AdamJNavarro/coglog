using CogLog.App.Features.Topic.Get;
using MediatR;

namespace CogLog.App.Features.Topic.GetById;

public record GetTopicByIdQuery(int Id) : IRequest<TopicDto>;
