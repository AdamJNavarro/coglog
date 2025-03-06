using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Data.Topic;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Topic.Queries;

public class GetTopicsBySubjectHandler(ITopicRepo repo)
    : IRequestHandler<GetTopicsBySubjectQuery, List<TopicDto>>
{
    public async Task<List<TopicDto>> Handle(
        GetTopicsBySubjectQuery request,
        CancellationToken cancellationToken
    )
    {
        var topics = await repo.GetTopicsBySubjectAsync(request.SubjectId);
        return topics.Select(x => x.ToTopicDto()).ToList();
    }
}
