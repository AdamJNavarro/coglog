using MediatR;

namespace CogLog.App.Features.Category.Commands;

public record CreateCategoryCommand(string Name, string? Icon, string? Description) : IRequest<int>;
