using MediatR;

namespace CogLog.App.Features.Category.Commands;

public record UpdateCategoryCommand(int Id, string Name, string? Icon, string? Description)
    : IRequest<Unit>;
