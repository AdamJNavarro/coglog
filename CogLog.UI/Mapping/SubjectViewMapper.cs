using CogLog.UI.Models.Subject;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public static class SubjectViewMapper
{
    public static BaseSubjectVm ToBaseSubjectVm(this SubjectDto subject)
    {
        var vm = new BaseSubjectVm
        {
            Id = subject.Id,
            Label = subject.Label,
            Icon = subject.Icon,
            CategoryId = subject.CategoryId,
        };
        return vm;
    }

    public static List<BaseSubjectVm> ToBaseSubjectVmList(this IEnumerable<SubjectDto> subjects)
    {
        return subjects.Select(x => x.ToBaseSubjectVm()).ToList();
    }
}
