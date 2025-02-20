using CogLog.App.Contracts.Data.Tag;
using CogLog.App.Features.Tag.Commands;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class TagMapper
{
    public static TagDto ToTagDto(this Tag tag)
    {
        return new TagDto(tag.Id, tag.Label, tag.Icon, tag.SubjectId);
    }

    public static Tag ToTag(this CreateTagCommand request)
    {
        return new Tag
        {
            Label = request.Label,
            Icon = request.Icon,
            SubjectId = request.SubjectId,
        };
    }

    public static Tag ToTag(this UpdateTagCommand request)
    {
        return new Tag
        {
            Id = request.Id,
            Label = request.Label,
            Icon = request.Icon,
            SubjectId = request.SubjectId,
        };
    }
}
