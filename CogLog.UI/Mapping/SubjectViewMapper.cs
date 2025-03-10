using CogLog.UI.Models.Subject;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public static class SubjectViewMapper
{
    public static SubjectMinimalVm ToSubjectMinimalVm(this SubjectMinimalDto subject)
    {
        return new SubjectMinimalVm
        {
            Id = subject.Id,
            Name = subject.Name,
            Icon = subject.Icon,
        };
    }

    public static BaseSubjectVm ToBaseSubjectVm(this SubjectDto subject)
    {
        return new BaseSubjectVm
        {
            Id = subject.Id,
            Name = subject.Name,
            Icon = subject.Icon,
            CategoryId = subject.CategoryId,
        };
    }

    public static List<BaseSubjectVm> ToBaseSubjectVmList(this IEnumerable<SubjectDto> subjects)
    {
        return subjects.Select(x => x.ToBaseSubjectVm()).ToList();
    }

    public static SubjectWithCategoryTopicsVm ToSubjectWithCategoryTopicsVm(
        this SubjectWithCategoryTopicsDto subject
    )
    {
        return new SubjectWithCategoryTopicsVm
        {
            Id = subject.Id,
            Name = subject.Name,
            Icon = subject.Icon,
            CategoryId = subject.CategoryId,
            Category = subject.Category.ToBaseCategoryVm(),
            Topics = subject.Topics.Select(x => x.ToBaseTopicVm()).ToList(),
        };
    }

    public static CreateSubjectCommand ToCreateSubjectCommand(this CreateSubjectVm subject)
    {
        return new CreateSubjectCommand
        {
            Name = subject.Name,
            Icon = subject.Icon,
            Description = subject.Description,
            CategoryId = subject.CategoryId,
        };
    }
}
