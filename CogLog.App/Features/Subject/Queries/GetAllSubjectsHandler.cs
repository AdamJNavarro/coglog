using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Contracts.Persistence;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public class GetAllSubjectsHandler(ISubjectRepo subjectRepo)
    : IRequestHandler<GetAllSubjectsQuery, List<SubjectMinimalDto>>
{
    public async Task<List<SubjectMinimalDto>> Handle(
        GetAllSubjectsQuery request,
        CancellationToken cancellationToken
    )
    {
        return await subjectRepo.GetAllSubjectsAsync(request.CategoryId);
    }
}
