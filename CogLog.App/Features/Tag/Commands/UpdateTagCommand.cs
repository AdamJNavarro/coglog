using MediatR;

namespace CogLog.App.Features.Tag.Commands;

public record UpdateTagCommand(int Id, string Label, string? Icon, int SubjectId) : IRequest<Unit>;
