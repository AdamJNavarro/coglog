using CogLog.App.Contracts.Data.Word;
using CogLog.UI.Contracts;
using CogLog.UI.Mapping;
using CogLog.UI.Models.Word;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Services;

public class WordService(IClient client, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        IWordService
{
    private readonly IClient _client = client;

    public async Task<WordPaginationVm> GetWordsAsync(WordsQueryParameters qp)
    {
        var data = await _client.WordsGetAsync(qp.Page, qp.PerPage, qp.Search);
        return data.ToWordPaginationVm();
    }

    public async Task<WordVm> GetWordDetailsAsync(int id)
    {
        var data = await _client.WordGetDetailsAsync(id);
        return data.ToWordVm();
    }

    public async Task<Response<Guid>> CreateWordAsync(WordCreateVm word)
    {
        try
        {
            AddBearerToken();
            var cmd = word.ToCreateWordCommand();
            await _client.WordCreateAsync(cmd);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> UpdateWordAsync(WordEditVm word)
    {
        try
        {
            AddBearerToken();
            await _client.WordUpdateAsync(word.Id.ToString(), word.ToUpdateWordCommand());
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteWordAsync(int id)
    {
        try
        {
            AddBearerToken();
            await _client.WordDeleteAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
