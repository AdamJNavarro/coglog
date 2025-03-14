using CogLog.App.Contracts.Data.Topic;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Topic.Queries;

public class GetAllTopicsHandler(ITopicRepo repo)
    : IRequestHandler<GetAllTopicsQuery, List<TopicMinimalDto>>
{
    public async Task<List<TopicMinimalDto>> Handle(
        GetAllTopicsQuery request,
        CancellationToken cancellationToken
    )
    {
        return await repo.GetAllTopicsAsync(request.SubjectId);
    }
}
