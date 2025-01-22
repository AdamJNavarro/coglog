using CogLog.App.Contracts.Persistence;
using FluentValidation;

namespace CogLog.App.Features.BrainBlock.Update;

internal class UpdateBrainBlockValidator : AbstractValidator<UpdateBrainBlockCommand>
{
    private readonly IBrainBlockRepo _brainBlockRepo;

    public UpdateBrainBlockValidator(IBrainBlockRepo brainBlockRepo)
    {
        _brainBlockRepo = brainBlockRepo;

        RuleFor(x => x.Id).NotNull().MustAsync(BlockMustExist);
    }

    private async Task<bool> BlockMustExist(int id, CancellationToken cancellationToken)
    {
        var brainBlock = await _brainBlockRepo.GetByIdAsync(id);
        return brainBlock != null;
    }
}
