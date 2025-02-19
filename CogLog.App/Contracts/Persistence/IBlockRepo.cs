using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface IBlockRepo : IBaseRepo<Block>
{
    Task CreateBlockAsync(Block block);
    Task UpdateBlockAsync(Block block);
    Task DeleteBlockAsync(Block block);
    Task<List<Block>> GetBlocksAsync();
    Task<List<Block>> GetBlocksWithRelationsAsync(
        bool includeCategory,
        bool includeSubject,
        bool includeTopics,
        bool includeTags
    );
    Task<Block?> GetBlockAsync(int id);
}
