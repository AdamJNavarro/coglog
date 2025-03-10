using MediatR;

namespace CogLog.App.Features.Subject.Commands;

public record CreateSubjectCommand(string Name, string? Icon, string? Description, int CategoryId)
    : IRequest<int>;
