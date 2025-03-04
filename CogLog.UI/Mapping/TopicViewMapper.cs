using CogLog.UI.Models.Topic;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public static class TopicViewMapper
{
    public static BaseTopicVm ToBaseTopicVm(this TopicDto topic)
    {
        return new BaseTopicVm
        {
            Id = topic.Id,
            Label = topic.Label,
            Description = topic.Description,
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
            Label = topic.Label,
            Description = topic.Description,
            SubjectId = topic.SubjectId,
        };
    }
}
