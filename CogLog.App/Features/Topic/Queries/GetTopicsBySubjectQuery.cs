using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Data.Topic;
using MediatR;

namespace CogLog.App.Features.Topic.Queries;

public record GetTopicsBySubjectQuery(int SubjectId) : IRequest<List<TopicDto>>;
