using AutoMapper;
using CogLog.UI.Contracts;
using CogLog.UI.Mapping;
using CogLog.UI.Models;
using CogLog.UI.Models.Block;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Services;

public class BlockService(IClient client, IMapper mapper, ILocalStorageService localStorageService)
    : BaseHttpService(client, localStorageService),
        IBlockService
{
    private readonly IClient _client = client;

    public async Task<List<BlockVm>> GetBlocksAsync()
    {
        AddBearerToken();
        var brainBlocks = await _client.BlocksAllAsync();
        return mapper.Map<List<BlockVm>>(brainBlocks);
    }

    // public async Task<BlockVm> GetBlockAsync(int id)
    // {
    //     var brainBlock = await _client.BlocksGETAsync(id);
    //     return mapper.Map<BlockVm>(brainBlock);
    // }

    public async Task<Response<Guid>> CreateBlockAsync(CreateBlockVm block)
    {
        try
        {
            // AddBearerToken();

            await _client.BlocksPOSTAsync(block.ToCreateBlockCommand());
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            Console.WriteLine("CBA EX");
            Console.WriteLine(ex.Message);
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteBlockAsync(int id)
    {
        try
        {
            await _client.BlocksDELETEAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
