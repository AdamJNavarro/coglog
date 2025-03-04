namespace CogLog.App.Contracts.Data.Subject;

public record SubjectDto(int Id, string Label, string? Icon, string? Description, int CategoryId);
