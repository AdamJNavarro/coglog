using MediatR;
using Vonavulary.App.Contracts.Data.Word;
using Vonavulary.App.Contracts.Persistence;
using Vonavulary.App.Models.Pagination;

namespace Vonavulary.App.Features.Word.Queries;

public class GetWordsHandler(IWordRepo wordRepo)
    : IRequestHandler<GetWordsQuery, PaginationResponse<WordDto>>
{
    public async Task<PaginationResponse<WordDto>> Handle(
        GetWordsQuery request,
        CancellationToken cancellationToken
    )
    {
        return await wordRepo.GetWordsAsync(request.Parameters);
    }
}
