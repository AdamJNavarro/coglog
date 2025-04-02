using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Word.Commands;

public class CreateWordHandler(IWordRepo wordRepo) : IRequestHandler<CreateWordCommand, int>
{
    public async Task<int> Handle(CreateWordCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateWordValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count != 0)
        {
            throw new BadRequestException("Invalid Word", validationResult);
        }

        var incomingWord = request.ToWord();

        await wordRepo.CreateWordAsync(incomingWord);

        return incomingWord.Id;
    }
}
