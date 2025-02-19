using CogLog.App.Contracts.Data;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public record GetCategoriesQuery : IRequest<List<CategoryDto>>;
