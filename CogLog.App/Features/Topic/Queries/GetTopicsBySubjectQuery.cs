using CogLog.App.Contracts.Data;
using MediatR;

namespace CogLog.App.Features.Topic.Queries;

public record GetTopicsBySubjectQuery(int SubjectId) : IRequest<List<TopicDto>>;
