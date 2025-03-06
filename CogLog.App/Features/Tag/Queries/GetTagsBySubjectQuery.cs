using CogLog.App.Contracts.Data.Tag;
using MediatR;

namespace CogLog.App.Features.Tag.Queries;

public record GetTagsBySubjectQuery(int SubjectId) : IRequest<List<TagDto>>;
