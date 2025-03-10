using CogLog.App.Contracts.Data.Tag;
using CogLog.App.Features.Tag.Commands;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class TagMapper
{
    public static TagMinimalDto ToTagMinimalDto(this Tag tag)
    {
        return new TagMinimalDto(tag.Id, tag.Name, tag.Icon);
    }

    public static TagDto ToTagDto(this Tag tag)
    {
        return new TagDto(tag.Id, tag.Name, tag.Icon, tag.Description, tag.SubjectId);
    }

    public static Tag ToTag(this CreateTagCommand request)
    {
        return new Tag
        {
            Name = request.Name,
            Icon = request.Icon,
            Description = request.Description,
            SubjectId = request.SubjectId,
        };
    }

    public static Tag ToTag(this UpdateTagCommand request)
    {
        return new Tag
        {
            Id = request.Id,
            Name = request.Name,
            Icon = request.Icon,
            Description = request.Description,
            SubjectId = request.SubjectId,
        };
    }
}
