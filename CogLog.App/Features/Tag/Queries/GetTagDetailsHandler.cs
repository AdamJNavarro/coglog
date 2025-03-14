using CogLog.App.Contracts.Data.Tag;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Tag.Queries;

public class GetTagDetailsHandler(ITagRepo tagRepo)
    : IRequestHandler<GetTagDetailsQuery, TagDetailsDto>
{
    public async Task<TagDetailsDto> Handle(
        GetTagDetailsQuery request,
        CancellationToken cancellationToken
    )
    {
        var tag = await tagRepo.GetTagDetailsAsync(request.Id);

        if (tag is null)
        {
            throw new NotFoundException(nameof(Tag), request.Id);
        }

        return tag;
    }
}
