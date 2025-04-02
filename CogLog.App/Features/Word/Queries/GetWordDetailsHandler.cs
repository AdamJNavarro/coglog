using CogLog.App.Contracts.Data.Word;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Word.Queries;

public class GetWordDetailsHandler(IWordRepo wordRepo)
    : IRequestHandler<GetWordDetailsQuery, WordDto>
{
    public async Task<WordDto> Handle(
        GetWordDetailsQuery request,
        CancellationToken cancellationToken
    )
    {
        var word =
            await wordRepo.GetEntityAsync(request.Id)
            ?? throw new NotFoundException(nameof(Word), request.Id);
        return word.ToWordDto();
    }
}
