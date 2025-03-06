using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Data.Topic;
using CogLog.App.Features.Topic.Commands;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class TopicMapper
{
    public static TopicMinimalDto ToTopicMinimalDto(this Topic topic)
    {
        return new TopicMinimalDto(topic.Id, topic.Label, topic.Icon);
    }

    public static List<TopicMinimalDto> ToTopicMinimalDtoList(this List<Topic> topics)
    {
        return topics.Select(x => x.ToTopicMinimalDto()).ToList();
    }

    public static TopicDto ToTopicDto(this Topic topic)
    {
        return new TopicDto(topic.Id, topic.Label, topic.Icon, topic.Description, topic.SubjectId);
    }

    public static Topic ToTopic(this CreateTopicCommand request)
    {
        return new Topic
        {
            Label = request.Label,
            Icon = request.Icon,
            Description = request.Description,
            SubjectId = request.SubjectId,
        };
    }
}
