using MediatR;

namespace CogLog.App.Features.Tag.Commands;

public record CreateTagCommand(string Label, string? Icon, int SubjectId) : IRequest<int>;
