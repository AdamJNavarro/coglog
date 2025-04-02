using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Word.Commands;

public class UpdateWordHandler(IWordRepo wordRepo) : IRequestHandler<UpdateWordCommand, Unit>
{
    public async Task<Unit> Handle(UpdateWordCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateWordValidator(wordRepo);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count != 0)
        {
            throw new BadRequestException("Invalid Word", validationResult);
        }

        var word = request.ToWord();
        await wordRepo.UpdateWordAsync(word);
        return Unit.Value;
    }
}
