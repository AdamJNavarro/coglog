using CogLog.App.Contracts.Data;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public record GetCategoryWithBrainBlocksQuery(int Id) : IRequest<CategoryWithBrainBlocksDto>;
