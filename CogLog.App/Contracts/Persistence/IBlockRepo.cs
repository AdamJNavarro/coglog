using CogLog.App.Contracts.Data.Block;
using CogLog.App.Models.Pagination;
using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface IBlockRepo : IBaseRepo<Block>
{
    Task CreateBlockAsync(Block block);
    Task UpdateBlockAsync(Block block);
    Task DeleteBlockAsync(Block block);
    Task<List<BlocksByDayDto>> GetBlocksByDayAsync();
    Task<Block?> GetBlockAsync(int id);
    Task<PaginationResponse<BlockDto>> GetBlocksAsync(BlocksQueryParameters parameters);
}
