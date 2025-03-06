using CogLog.UI.Models;
using CogLog.UI.Models.Block;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface IBlockService
{
    Task<List<BlockVm>> GetBlocksAsync();

    Task<List<BlockByDayVm>> GetBlocksByDayAsync();

    // Task<BlockVm> GetBlockAsync(int id);
    Task<Response<Guid>> CreateBlockAsync(CreateBlockVm block);

    Task<Response<Guid>> DeleteBlockAsync(int id);
}
