using CogLog.App.Contracts.Data;
using CogLog.App.Contracts.Data.Category;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public record GetCategoryWithBlocksQuery(int Id) : IRequest<CategoryWithBlocksDto>;
