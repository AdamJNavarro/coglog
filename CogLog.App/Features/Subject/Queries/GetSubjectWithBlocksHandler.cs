using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public class GetSubjectWithBlocksHandler(ISubjectRepo repo)
    : IRequestHandler<GetSubjectWithBlocksQuery, SubjectWithBlocksDto>
{
    public async Task<SubjectWithBlocksDto> Handle(
        GetSubjectWithBlocksQuery request,
        CancellationToken cancellationToken
    )
    {
        var subject = await repo.GetSubjectWithRelationsAsync(
            request.Id,
            false,
            false,
            false,
            true
        );
        return subject.ToSubjectWithBlocksDto();
    }
}
