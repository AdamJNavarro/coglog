using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public class GetSubjectDetailsHandler(ISubjectRepo subjectRepo)
    : IRequestHandler<GetSubjectDetailsQuery, SubjectDetailsDto>
{
    public async Task<SubjectDetailsDto> Handle(
        GetSubjectDetailsQuery request,
        CancellationToken cancellationToken
    )
    {
        var subject = await subjectRepo.GetSubjectDetailsAsync(request.Id);

        if (subject is null)
        {
            throw new NotFoundException(nameof(Subject), request.Id);
        }

        return subject;
    }
}
