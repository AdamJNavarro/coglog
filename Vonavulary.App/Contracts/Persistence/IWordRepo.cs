using Vonavulary.App.Contracts.Data.Word;
using Vonavulary.App.Models.Pagination;
using Vonavulary.Domain;

namespace Vonavulary.App.Contracts.Persistence;

public interface IWordRepo : IBaseRepo<Word>
{
    Task CreateWordAsync(Word word);
    Task UpdateWordAsync(Word word);
    Task DeleteWordAsync(Word word);
    Task<PaginationResponse<WordDto>> GetWordsAsync(WordsQueryParameters parameters);

    Task<bool> IsWordUnique(string spelling);
}
