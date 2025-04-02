using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using MediatR;

namespace CogLog.App.Features.Word.Commands;

public class DeleteWordHandler(IWordRepo wordRepo) : IRequestHandler<DeleteWordCommand, Unit>
{
    public async Task<Unit> Handle(DeleteWordCommand request, CancellationToken cancellationToken)
    {
        var wordToDelete =
            await wordRepo.GetEntityAsync(request.Id)
            ?? throw new NotFoundException(nameof(Word), request.Id);
        await wordRepo.DeleteWordAsync(wordToDelete);

        return Unit.Value;
    }
}
