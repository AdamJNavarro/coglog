using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public class GetSubjectWithCategoryTopicsHandler(ISubjectRepo repo)
    : IRequestHandler<GetSubjectWithCategoryTopicsQuery, SubjectWithCategoryTopicsDto>
{
    public async Task<SubjectWithCategoryTopicsDto> Handle(
        GetSubjectWithCategoryTopicsQuery request,
        CancellationToken cancellationToken
    )
    {
        var subject = await repo.GetSubjectWithRelationsAsync(request.Id, true, true, false, false);
        return subject.ToSubjectWithCategoryTopicsDto();
    }
}
