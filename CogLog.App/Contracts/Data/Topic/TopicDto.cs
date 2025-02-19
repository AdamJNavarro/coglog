namespace CogLog.App.Contracts.Data;

public record TopicDto(int Id, string Label, string? Icon, string? Description, int SubjectId);
