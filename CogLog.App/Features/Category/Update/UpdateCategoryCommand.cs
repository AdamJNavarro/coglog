using MediatR;

namespace CogLog.App.Features.Category.Update;

public record UpdateCategoryCommand(int Id, string Label, string Icon, string? Description)
    : IRequest<Unit>;
