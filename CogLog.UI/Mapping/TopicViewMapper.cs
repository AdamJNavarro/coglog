using CogLog.UI.Models.Topic;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public static class TopicViewMapper
{
    public static TopicMinimalVm ToTopicMinimalVm(this TopicMinimalDto topic)
    {
        return new TopicMinimalVm
        {
            Id = topic.Id,
            Name = topic.Name,
            Icon = topic.Icon,
        };
    }

    public static BaseTopicVm ToBaseTopicVm(this TopicDto topic)
    {
        return new BaseTopicVm
        {
            Id = topic.Id,
            Name = topic.Name,
            SubjectId = topic.SubjectId,
        };
    }

    public static List<BaseTopicVm> ToBaseTopicVmList(this IEnumerable<TopicDto> topics)
    {
        return topics.Select(x => x.ToBaseTopicVm()).ToList();
    }

    public static CreateTopicCommand ToCreateTopicCommand(this CreateTopicVm topic)
    {
        return new CreateTopicCommand
        {
            Name = topic.Name,
            Description = topic.Description,
            SubjectId = topic.SubjectId,
        };
    }
}
