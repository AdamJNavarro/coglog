using CogLog.App.Contracts.Data.Category;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public record GetCategoryQuery(int Id) : IRequest<CategoryDto>;
