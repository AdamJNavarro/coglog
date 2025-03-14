using CogLog.App.Contracts.Data.Topic;
using MediatR;

namespace CogLog.App.Features.Topic.Queries;

public record GetTopicDetailsQuery(int Id) : IRequest<TopicDetailsDto>;
