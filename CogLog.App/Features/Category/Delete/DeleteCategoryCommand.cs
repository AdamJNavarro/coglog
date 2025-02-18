using MediatR;

namespace CogLog.App.Features.Category.Delete;

public record DeleteCategoryCommand(int Id) : IRequest<Unit>;
