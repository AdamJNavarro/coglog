using MediatR;

namespace CogLog.App.Features.Subject.Commands;

public record CreateSubjectCommand(string Label, string? Icon, string? Description, int CategoryId)
    : IRequest<int>;
