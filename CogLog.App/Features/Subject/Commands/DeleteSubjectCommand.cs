using MediatR;

namespace CogLog.App.Features.Subject.Commands;

public record DeleteSubjectCommand(int Id) : IRequest<Unit>;
