using CogLog.App.Contracts.Data.Word;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Models.Pagination;
using MediatR;

namespace CogLog.App.Features.Word.Queries;

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
