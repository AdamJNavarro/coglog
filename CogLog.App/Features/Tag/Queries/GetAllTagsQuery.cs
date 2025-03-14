using CogLog.App.Contracts.Data.Tag;
using MediatR;

namespace CogLog.App.Features.Tag.Queries;

public record GetAllTagsQuery(int? SubjectId) : IRequest<List<TagMinimalDto>>;
