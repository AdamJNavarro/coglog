using CogLog.App.Contracts.Data.Subject;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public record GetSubjectWithCategoryTopicsQuery(int Id) : IRequest<SubjectWithCategoryTopicsDto>;
