using MediatR;
using Vonavulary.App.Contracts.Data.Word;
using Vonavulary.App.Models.Pagination;

namespace Vonavulary.App.Features.Word.Queries;

public record GetWordsQuery(WordsQueryParameters Parameters)
    : IRequest<PaginationResponse<WordDto>>;
