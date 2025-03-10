namespace CogLog.App.Contracts.Data.Subject;

public record SubjectDto(int Id, string Name, string? Icon, string? Description, int CategoryId);
