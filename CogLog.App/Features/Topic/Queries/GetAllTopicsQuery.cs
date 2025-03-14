using CogLog.App.Contracts.Data.Topic;
using MediatR;

namespace CogLog.App.Features.Topic.Queries;

public record GetAllTopicsQuery(int? SubjectId) : IRequest<List<TopicMinimalDto>>;
