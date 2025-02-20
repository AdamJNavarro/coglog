using MediatR;

namespace CogLog.App.Features.Subject.Commands;

public record UpdateSubjectCommand(
    int Id,
    string Label,
    string? Icon,
    string? Description,
    int CategoryId
) : IRequest<Unit>;
