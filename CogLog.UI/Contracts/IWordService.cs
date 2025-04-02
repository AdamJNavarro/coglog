using CogLog.App.Contracts.Data.Word;
using CogLog.UI.Models.Word;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface IWordService
{
    Task<WordPaginationVm> GetWordsAsync(WordsQueryParameters qp);
    Task<WordVm> GetWordDetailsAsync(int id);
    Task<Response<Guid>> CreateWordAsync(WordCreateVm word);
    Task<Response<Guid>> UpdateWordAsync(WordEditVm word);
    Task<Response<Guid>> DeleteWordAsync(int id);
}
