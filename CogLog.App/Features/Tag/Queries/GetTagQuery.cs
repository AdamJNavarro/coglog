using CogLog.App.Contracts.Data.Tag;
using MediatR;

namespace CogLog.App.Features.Tag.Queries;

public record GetTagQuery(int Id) : IRequest<TagDto>;
