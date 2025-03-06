namespace CogLog.App.Contracts.Data.Topic;

public record TopicDto(int Id, string Label, string? Icon, string? Description, int SubjectId);
