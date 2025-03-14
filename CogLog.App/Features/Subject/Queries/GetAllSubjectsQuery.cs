using CogLog.App.Contracts.Data.Subject;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public record GetAllSubjectsQuery(int? CategoryId) : IRequest<List<SubjectMinimalDto>>;
