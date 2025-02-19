using CogLog.App.Contracts.Data;
using CogLog.App.Features.Subject.Commands;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class SubjectMapper
{
    public static SubjectWithBlocksDto ToSubjectWithBlocksDto(this Subject subject)
    {
        return new SubjectWithBlocksDto(
            subject.Id,
            subject.Label,
            subject.Icon,
            subject.Description,
            subject.Blocks.Select(x => x.ToBlockDto()).ToList()
        );
    }

    public static SubjectDto ToSubjectDto(this Subject subject)
    {
        return new SubjectDto(
            subject.Id,
            subject.Label,
            subject.Icon,
            subject.Description,
            subject.CategoryId
        );
    }

    public static Subject ToSubject(this CreateSubjectCommand request)
    {
        return new Subject
        {
            Label = request.Label,
            Icon = request.Icon,
            Description = request.Description,
            CategoryId = request.CategoryId,
        };
    }
}
