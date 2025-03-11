using CogLog.App.Contracts.Data.Tag;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Tag.Queries;

public class GetTagHandler(ITagRepo tagRepo) : IRequestHandler<GetTagQuery, TagDto>
{
    public async Task<TagDto> Handle(GetTagQuery request, CancellationToken cancellationToken)
    {
        var tag = await tagRepo.GetTagAsync(request.Id);

        if (tag is null)
        {
            throw new NotFoundException(nameof(Tag), request.Id);
        }

        return tag.ToTagDto();
    }
}
