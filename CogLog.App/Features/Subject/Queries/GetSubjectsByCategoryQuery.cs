using CogLog.App.Contracts.Data.Subject;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public record GetSubjectsByCategoryQuery(int CategoryId) : IRequest<List<SubjectDto>>;
