using MediatR;

namespace CogLog.App.Features.Tag.Commands;

public record CreateTagCommand(string Name, string? Icon, string? Description, int SubjectId)
    : IRequest<int>;
