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

    public static List<TopicMinimalVm> ToTopicMinimalVmList(
        this IEnumerable<TopicMinimalDto> topics
    )
    {
        return topics.Select(x => x.ToTopicMinimalVm()).ToList();
    }

    public static TopicDetailsVm ToTopicDetailsVm(this TopicDetailsDto topic)
    {
        return new TopicDetailsVm()
        {
            Id = topic.Id,
            Name = topic.Name,
            Icon = topic.Icon,
            Description = topic.Description,
            SubjectId = topic.SubjectId,
            Subject = topic.Subject.ToSubjectMinimalVm(),
        };
    }

    // public static BaseTopicVm ToBaseTopicVm(this TopicDto topic)
    // {
    //     return new BaseTopicVm
    //     {
    //         Id = topic.Id,
    //         Name = topic.Name,
    //         SubjectId = topic.SubjectId,
    //     };
    // }
    //
    // public static List<BaseTopicVm> ToBaseTopicVmList(this IEnumerable<TopicDto> topics)
    // {
    //     return topics.Select(x => x.ToBaseTopicVm()).ToList();
    // }

    public static CreateTopicCommand ToCreateTopicCommand(this TopicCreateVm topic)
    {
        return new CreateTopicCommand
        {
            Name = topic.Name,
            Icon = topic.Icon,
            Description = topic.Description,
            SubjectId = topic.SubjectId,
        };
    }

    public static UpdateTopicCommand ToUpdateTopicCommand(this TopicEditVm topic)
    {
        return new UpdateTopicCommand()
        {
            Id = topic.Id,
            Name = topic.Name,
            Icon = topic.Icon,
            Description = topic.Description,
            SubjectId = topic.SubjectId,
        };
    }
}
