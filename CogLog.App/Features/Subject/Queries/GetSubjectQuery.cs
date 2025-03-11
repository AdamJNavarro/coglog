using CogLog.App.Contracts.Data.Subject;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public record GetSubjectQuery(int Id) : IRequest<SubjectDto>;
