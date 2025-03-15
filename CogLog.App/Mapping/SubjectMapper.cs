using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Features.Subject.Commands;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class SubjectMapper
{
    public static SubjectMinimalDto ToSubjectMinimalDto(this Subject subject)
    {
        return new SubjectMinimalDto(subject.Id, subject.Name, subject.Icon, subject.CategoryId);
    }

    public static List<SubjectMinimalDto> ToSubjectMinimalDtoList(this List<Subject> subjects)
    {
        return subjects.Select(x => x.ToSubjectMinimalDto()).ToList();
    }

    public static SubjectPaginatedDto ToSubjectPaginatedDto(this Subject subject)
    {
        return new SubjectPaginatedDto(
            subject.Id,
            subject.Name,
            subject.Icon,
            subject.CategoryId,
            subject.Category?.ToCategoryMinimalDto()
        );
    }

    public static List<SubjectPaginatedDto> ToSubjectPaginatedDtoList(this List<Subject> subjects)
    {
        return subjects.Select(x => x.ToSubjectPaginatedDto()).ToList();
    }

    public static SubjectDetailsDto ToSubjectDetailsDto(this Subject subject)
    {
        return new SubjectDetailsDto(
            subject.Id,
            subject.Name,
            subject.Icon,
            subject.Description,
            subject.CategoryId,
            subject.Category?.ToCategoryMinimalDto(),
            subject.Topics.ToTopicMinimalDtoList(),
            subject.Tags.ToTagMinimalDtoList()
        );
    }

    public static Subject ToSubject(this CreateSubjectCommand request)
    {
        return new Subject
        {
            Name = request.Name,
            Icon = request.Icon,
            Description = request.Description,
            CategoryId = request.CategoryId,
        };
    }

    public static Subject ToSubject(this UpdateSubjectCommand request)
    {
        return new Subject
        {
            Id = request.Id,
            Name = request.Name,
            Icon = request.Icon,
            Description = request.Description,
            CategoryId = request.CategoryId,
        };
    }
}
