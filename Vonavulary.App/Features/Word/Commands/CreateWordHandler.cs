using MediatR;
using Vonavulary.App.Contracts.Persistence;
using Vonavulary.App.Exceptions;
using Vonavulary.App.Mapping;

namespace Vonavulary.App.Features.Word.Commands;

public class CreateWordHandler(IWordRepo wordRepo) : IRequestHandler<CreateWordCommand, int>
{
    public async Task<int> Handle(CreateWordCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateWordValidator(wordRepo);
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
