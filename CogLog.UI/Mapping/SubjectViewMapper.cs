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

    public static List<SubjectMinimalVm> ToSubjectMinimalVmList(
        this IEnumerable<SubjectMinimalDto> subjects
    )
    {
        return subjects.Select(x => x.ToSubjectMinimalVm()).ToList();
    }

    public static SubjectPaginatedVm ToSubjectPaginatedVm(this SubjectPaginatedDto subject)
    {
        return new SubjectPaginatedVm
        {
            Id = subject.Id,
            Name = subject.Name,
            Icon = subject.Icon,
            CategoryId = subject.CategoryId,
            Category = subject.Category?.ToCategoryMinimalVm(),
        };
    }

    public static SubjectPaginationVm ToSubjectPaginationVm(
        this SubjectPaginatedDtoPaginationResponse resp
    )
    {
        return new SubjectPaginationVm
        {
            Pagination = resp.Pagination.ToPaginationMetadataVm(),
            Data = resp.Data.Select(x => x.ToSubjectPaginatedVm()).ToList(),
        };
    }

    public static SubjectDetailsVm ToSubjectDetailsVm(this SubjectDetailsDto subject)
    {
        return new SubjectDetailsVm
        {
            Id = subject.Id,
            Name = subject.Name,
            Icon = subject.Icon,
            Description = subject.Description,
            CategoryId = subject.CategoryId,
            Category = subject.Category?.ToCategoryMinimalVm(),
            Topics = subject.Topics.ToTopicMinimalVmList(),
            Tags = subject.Tags.ToTagMinimalVmList(),
        };
    }

    public static CreateSubjectCommand ToCreateSubjectCommand(this SubjectCreateVm subject)
    {
        return new CreateSubjectCommand
        {
            Name = subject.Name,
            Icon = subject.Icon,
            Description = subject.Description,
            CategoryId = subject.CategoryId,
        };
    }

    public static UpdateSubjectCommand ToUpdateSubjectCommand(this SubjectEditVm subject)
    {
        return new UpdateSubjectCommand
        {
            Id = subject.Id,
            Name = subject.Name,
            Icon = subject.Icon,
            Description = subject.Description,
            CategoryId = subject.CategoryId,
        };
    }
}
