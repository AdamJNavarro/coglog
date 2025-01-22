using AutoMapper;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.BrainBlock.Create;

public class CreateBrainBlockHandler(IMapper mapper, IBrainBlockRepo brainBlockRepo)
    : IRequestHandler<CreateBrainBlockCommand, int>
{
    public async Task<int> Handle(
        CreateBrainBlockCommand request,
        CancellationToken cancellationToken
    )
    {
        var validator = new CreateBrainBlockValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count > 0)
        {
            throw new BadRequestException("Invalid Brain Block", validationResult);
        }

        var incomingBrainBlock = mapper.Map<Domain.BrainBlock>(request);

        await brainBlockRepo.CreateAsync(incomingBrainBlock);

        return incomingBrainBlock.Id;
    }
}
