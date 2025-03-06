using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public class GetSubjectsByCategoryHandler(ISubjectRepo repo)
    : IRequestHandler<GetSubjectsByCategoryQuery, List<SubjectDto>>
{
    public async Task<List<SubjectDto>> Handle(
        GetSubjectsByCategoryQuery request,
        CancellationToken cancellationToken
    )
    {
        var subjects = await repo.GetSubjectsByCategoryAsync(request.CategoryId);
        return subjects.Select(x => x.ToSubjectDto()).ToList();
    }
}
