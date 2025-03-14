using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Models.Pagination;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public class GetPaginatedSubjectsHandler(ISubjectRepo repo)
    : IRequestHandler<GetPaginatedSubjectsQuery, PaginationResponse<SubjectPaginatedDto>>
{
    public async Task<PaginationResponse<SubjectPaginatedDto>> Handle(
        GetPaginatedSubjectsQuery request,
        CancellationToken cancellationToken
    )
    {
        return await repo.GetPaginatedSubjectsAsync(request.Parameters);
    }
}
