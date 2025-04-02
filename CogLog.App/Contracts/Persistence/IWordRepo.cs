using CogLog.App.Contracts.Data.Word;
using CogLog.App.Models.Pagination;
using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface IWordRepo : IBaseRepo<Word>
{
    Task CreateWordAsync(Word word);
    Task UpdateWordAsync(Word word);
    Task DeleteWordAsync(Word word);
    Task<PaginationResponse<WordDto>> GetWordsAsync(WordsQueryParameters parameters);

    Task<bool> IsWordUnique(string spelling);
}
