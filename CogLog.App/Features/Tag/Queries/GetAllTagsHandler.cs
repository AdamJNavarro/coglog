using CogLog.App.Contracts.Data.Tag;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Tag.Queries;

public class GetAllTagsHandler(ITagRepo tagRepo)
    : IRequestHandler<GetAllTagsQuery, List<TagMinimalDto>>
{
    public async Task<List<TagMinimalDto>> Handle(
        GetAllTagsQuery request,
        CancellationToken cancellationToken
    )
    {
        return await tagRepo.GetAllTagsAsync(request.SubjectId);
    }
}
