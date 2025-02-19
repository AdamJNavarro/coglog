using MediatR;

namespace CogLog.App.Features.Category.Commands;

public record CreateCategoryCommand(string Label, string Icon, string? Description) : IRequest<int>;
