using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Data.Subject;
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

    public static SubjectWithCategoryTopicsDto ToSubjectWithCategoryTopicsDto(this Subject subject)
    {
        return new SubjectWithCategoryTopicsDto(
            subject.Id,
            subject.Label,
            subject.Icon,
            subject.Description,
            subject.CategoryId,
            subject.Category.ToCategoryDto(),
            subject.Topics.Select(x => x.ToTopicDto()).ToList()
        );
    }

    public static SubjectMinimalDto ToSubjectMinimalDto(this Subject subject)
    {
        return new SubjectMinimalDto(subject.Id, subject.Label, subject.Icon);
    }

    public static List<SubjectMinimalDto> ToSubjectMinimalDtoList(this List<Subject> subjects)
    {
        return subjects.Select(x => x.ToSubjectMinimalDto()).ToList();
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

    public static Subject ToSubject(this UpdateSubjectCommand request)
    {
        return new Subject
        {
            Id = request.Id,
            Label = request.Label,
            Icon = request.Icon,
            Description = request.Description,
            CategoryId = request.CategoryId,
        };
    }
}
