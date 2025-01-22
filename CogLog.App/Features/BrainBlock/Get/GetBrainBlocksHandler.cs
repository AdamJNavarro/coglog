using AutoMapper;
using CogLog.App.Contracts.Persistence;
using MediatR;

namespace CogLog.App.Features.BrainBlock.Get;

public class GetBrainBlocksHandler(IMapper mapper, IBrainBlockRepo brainBlockRepo)
    : IRequestHandler<GetBrainBlocksQuery, List<BrainBlockDto>>
{
    public async Task<List<BrainBlockDto>> Handle(
        GetBrainBlocksQuery request,
        CancellationToken cancellationToken
    )
    {
        var brainBlocks = await brainBlockRepo.GetAsync();
        var data = mapper.Map<List<BrainBlockDto>>(brainBlocks);
        return data;
    }
}
