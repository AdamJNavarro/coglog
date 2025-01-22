using AutoMapper;
using CogLog.UI.Contracts;
using CogLog.UI.Models;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Services;

public class BrainBlockService(
    IClient client,
    IMapper mapper,
    ILocalStorageService localStorageService
) : BaseHttpService(client, localStorageService), IBrainBlockService
{
    private readonly IClient _client = client;

    public async Task<List<BrainBlockVm>> GetBrainBlocks()
    {
        AddBearerToken();
        var brainBlocks = await _client.BrainBlockAllAsync();
        return mapper.Map<List<BrainBlockVm>>(brainBlocks);
    }

    public async Task<BrainBlockVm> GetBrainBlockById(int id)
    {
        var brainBlock = await _client.BrainBlockGETAsync(id);
        return mapper.Map<BrainBlockVm>(brainBlock);
    }

    public async Task<Response<Guid>> CreateBrainBlock(CreateBrainBlockVm brainBlock)
    {
        try
        {
            AddBearerToken();

            var createLeaveTypeCommand = mapper.Map<CreateBrainBlockCommand>(brainBlock);
            await _client.BrainBlockPOSTAsync(createLeaveTypeCommand);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> EditBrainBlock(int id, BrainBlockVm brainBlock)
    {
        try
        {
            var updateBrainBlockCommand = mapper.Map<UpdateBrainBlockCommand>(brainBlock);
            await _client.BrainBlockPUTAsync(id.ToString(), updateBrainBlockCommand);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteBrainBlock(int id)
    {
        try
        {
            await _client.BrainBlockDELETEAsync(id);
            return new Response<Guid>() { Success = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
