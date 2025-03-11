using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public class GetSubjectHandler(ISubjectRepo subjectRepo)
    : IRequestHandler<GetSubjectQuery, SubjectDto>
{
    public async Task<SubjectDto> Handle(
        GetSubjectQuery request,
        CancellationToken cancellationToken
    )
    {
        var subject = await subjectRepo.GetSubjectAsync(request.Id);

        if (subject is null)
        {
            throw new NotFoundException(nameof(Subject), request.Id);
        }

        return subject.ToSubjectDto();
    }
}
