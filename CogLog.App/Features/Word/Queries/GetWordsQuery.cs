using CogLog.App.Contracts.Data.Word;
using CogLog.App.Models.Pagination;
using MediatR;

namespace CogLog.App.Features.Word.Queries;

public record GetWordsQuery(WordsQueryParameters Parameters)
    : IRequest<PaginationResponse<WordDto>>;
