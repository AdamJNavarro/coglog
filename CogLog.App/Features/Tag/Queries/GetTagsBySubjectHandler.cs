using CogLog.App.Contracts.Data.Tag;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Tag.Queries;

public class GetTagsBySubjectHandler(ITagRepo repo)
    : IRequestHandler<GetTagsBySubjectQuery, List<TagDto>>
{
    public async Task<List<TagDto>> Handle(
        GetTagsBySubjectQuery request,
        CancellationToken cancellationToken
    )
    {
        var data = await repo.GetTagsBySubjectAsync(request.SubjectId);
        return data.Select(x => x.ToTagDto()).ToList();
    }
}
