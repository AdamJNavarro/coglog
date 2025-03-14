using CogLog.App.Contracts.Data.Subject;
using CogLog.App.Models.Pagination;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public record GetPaginatedSubjectsQuery(SubjectQueryParameters Parameters)
    : IRequest<PaginationResponse<SubjectPaginatedDto>>;
