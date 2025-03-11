using CogLog.App.Contracts.Data.Category;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public record GetCategoryDetailsQuery(int Id) : IRequest<CategoryDetailsDto>;
