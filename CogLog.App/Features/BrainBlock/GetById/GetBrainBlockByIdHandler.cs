using AutoMapper;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.BrainBlock.GetById;

public class GetBrainBlockByIdHandler(IMapper mapper, IBrainBlockRepo brainBlockRepo)
    : IRequestHandler<GetBrainBlockByIdQuery, BrainBlockDetailsDto>
{
    public async Task<BrainBlockDetailsDto> Handle(
        GetBrainBlockByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var brainBlock = await brainBlockRepo.GetByIdAsync(request.Id);

        if (brainBlock == null)
        {
            throw new NotFoundException(nameof(BrainBlock), request.Id);
        }

        return mapper.Map<BrainBlockDetailsDto>(brainBlock);
    }
}
