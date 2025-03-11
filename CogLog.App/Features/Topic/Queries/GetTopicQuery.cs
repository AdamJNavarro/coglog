using CogLog.App.Contracts.Data.Topic;
using MediatR;

namespace CogLog.App.Features.Topic.Queries;

public record GetTopicQuery(int Id) : IRequest<TopicDto>;
