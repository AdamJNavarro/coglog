using MediatR;

namespace CogLog.App.Features.Category.Commands;

public record DeleteCategoryCommand(int Id) : IRequest<Unit>;
