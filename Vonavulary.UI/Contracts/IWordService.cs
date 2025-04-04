using Vonavulary.App.Contracts.Data.Word;
using Vonavulary.UI.Models.Word;
using Vonavulary.UI.Services.Base;

namespace Vonavulary.UI.Contracts;

public interface IWordService
{
    Task<WordPaginationVm> GetWordsAsync(WordsQueryParameters qp);
    Task<WordVm> GetWordDetailsAsync(int id);
    Task<Response<Guid>> CreateWordAsync(WordCreateVm word);
    Task<Response<Guid>> UpdateWordAsync(WordEditVm word);
    Task<Response<Guid>> DeleteWordAsync(int id);
}
