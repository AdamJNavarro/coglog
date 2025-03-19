using CogLog.App.Contracts.Data.Block;
using CogLog.UI.Contracts;
using CogLog.UI.Mapping;
using CogLog.UI.Models.Block;
using CogLog.UI.Models.Shared.Pagination;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Services;

public class BlockService(IClient client, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        IBlockService
{
    private readonly IClient _client = client;

    public async Task<PaginationResponseVm<BlockVm>> GetBlocksAsync(BlocksQueryParameters fp)
    {
        var data = await _client.BlocksAsync(
            fp.Page,
            fp.PerPage,
            fp.SearchTerm,
            fp.CategoryName,
            fp.SubjectName
        );
        return data.ToPaginationBlockVm();
    }

    public async Task<List<BlockByDayVm>> GetBlocksByDayAsync()
    {
        var data = await _client.BlocksByDayGETAsync();
        return data.ToBlockByDayVmList();
    }

    public async Task<BlockDetailsVm> GetBlockDetailsAsync(int id)
    {
        var block = await _client.BlockGetDetailsAsync(id);
        return block.ToBlockDetailsVm();
    }

    public async Task<Response<Guid>> CreateBlockAsync(BlockCreateVm block)
    {
        try
        {
            AddBearerToken();
            await _client.BlockCreateAsync(block.ToCreateBlockCommand());
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> UpdateBlockAsync(BlockEditVm block)
    {
        try
        {
            AddBearerToken();
            await _client.BlockUpdateAsync(block.Id.ToString(), block.ToUpdateBlockCommand());
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteBlockAsync(int id)
    {
        try
        {
            AddBearerToken();
            await _client.BlockDeleteAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
