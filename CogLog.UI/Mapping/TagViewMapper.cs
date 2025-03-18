using CogLog.UI.Models.Tag;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public static class TagViewMapper
{
    public static TagMinimalVm ToTagMinimalVm(this TagMinimalDto topic)
    {
        return new TagMinimalVm
        {
            Id = topic.Id,
            Name = topic.Name,
            Icon = topic.Icon,
        };
    }

    public static List<TagMinimalVm> ToTagMinimalVmList(this IEnumerable<TagMinimalDto> tags)
    {
        return tags.Select(x => x.ToTagMinimalVm()).ToList();
    }

    public static TagDetailsVm ToTagDetailsVm(this TagDetailsDto tag)
    {
        return new TagDetailsVm()
        {
            Id = tag.Id,
            Name = tag.Name,
            Icon = tag.Icon,
            Description = tag.Description,
            SubjectId = tag.SubjectId,
            Subject = tag.Subject.ToSubjectMinimalVm(),
        };
    }

    public static CreateTagCommand ToCreateTagCommand(this TagCreateVm tag)
    {
        return new CreateTagCommand
        {
            Name = tag.Name,
            Icon = tag.Icon,
            Description = tag.Description,
            SubjectId = tag.SubjectId,
        };
    }

    public static UpdateTagCommand ToUpdateTagCommand(this TagEditVm tag)
    {
        return new UpdateTagCommand
        {
            Id = tag.Id,
            Name = tag.Name,
            Icon = tag.Icon,
            Description = tag.Description,
            SubjectId = tag.SubjectId,
        };
    }
}
