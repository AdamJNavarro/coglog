using CogLog.App.Contracts.Data;
using MediatR;

namespace CogLog.App.Features.Subject.Queries;

public record GetSubjectWithBlocksQuery(int Id) : IRequest<SubjectWithBlocksDto>;
