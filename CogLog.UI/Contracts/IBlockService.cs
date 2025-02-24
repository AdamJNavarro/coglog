using CogLog.UI.Models;
using CogLog.UI.Models.Block;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface IBlockService
{
    Task<List<BlockVm>> GetBlocks();

    Task<BlockVm> GetBlockById(int id);
    Task<Response<Guid>> CreateBlock(CreateBlockVm block);

    Task<Response<Guid>> EditBlock(int id, BlockVm block);

    Task<Response<Guid>> DeleteBlock(int id);
}
