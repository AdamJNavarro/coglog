using CogLog.App.Contracts.Data;
using MediatR;

namespace CogLog.App.Features.Category.Queries;

public record GetCategoryWithSubjectsQuery(int Id) : IRequest<CategoryWithSubjectsDto>;
