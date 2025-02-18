using MediatR;

namespace CogLog.App.Features.Category.Create;

public record CreateCategoryCommand(string Label, string Icon, string? Description) : IRequest<int>;
