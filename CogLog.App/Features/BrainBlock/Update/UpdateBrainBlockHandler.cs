using AutoMapper;
using CogLog.App.Contracts.Logging;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.BrainBlock.Update;

public class UpdateBrainBlockHandler(
    IMapper mapper,
    IBrainBlockRepo brainBlockRepo,
    IAppLogger<UpdateBrainBlockHandler> logger
) : IRequestHandler<UpdateBrainBlockCommand, Unit>
{
    public async Task<Unit> Handle(
        UpdateBrainBlockCommand request,
        CancellationToken cancellationToken
    )
    {
        var validator = new UpdateBrainBlockValidator(brainBlockRepo);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            logger.LogWarning(
                "Validation errors in update request for {0} - {1}",
                nameof(BrainBlock),
                request.Id
            );
            throw new BadRequestException("Invalid Leave type", validationResult);
        }

        var blockToUpdate = mapper.Map<Domain.BrainBlock>(request);

        await brainBlockRepo.UpdateAsync(blockToUpdate);

        return Unit.Value;
    }
}
