namespace CogLog.App.Contracts.Data.Tag;

public record TagDto(int Id, string Name, string? Icon, string? Description, int SubjectId);
