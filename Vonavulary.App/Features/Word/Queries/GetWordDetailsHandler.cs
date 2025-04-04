using MediatR;
using Vonavulary.App.Contracts.Data.Word;
using Vonavulary.App.Contracts.Persistence;
using Vonavulary.App.Exceptions;
using Vonavulary.App.Mapping;

namespace Vonavulary.App.Features.Word.Queries;

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
