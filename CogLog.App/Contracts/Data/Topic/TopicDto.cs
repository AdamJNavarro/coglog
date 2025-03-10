namespace CogLog.App.Contracts.Data.Topic;

public record TopicDto(int Id, string Name, string? Icon, string? Description, int SubjectId);
