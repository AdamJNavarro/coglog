using CogLog.App.Contracts.Data;
using CogLog.App.Features.Topic.Commands;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class TopicMapper
{
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
