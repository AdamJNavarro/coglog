using CogLog.App.Contracts.Data;
using MediatR;

namespace CogLog.App.Features.Category.Get;

public record GetCategoriesQuery : IRequest<List<CategoryDto>>;
