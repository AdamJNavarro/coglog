using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface IBrainBlockRepo : IBaseRepo<BrainBlock>
{
    Task CreateBrainBlockAsync(BrainBlock brainBlock);
    Task UpdateBrainBlockAsync(BrainBlock brainBlock);
    Task DeleteBrainBlockAsync(BrainBlock brainBlock);
    Task<List<BrainBlock>> GetBrainBlocksAsync();
    Task<List<BrainBlock>> GetBrainBlocksWithRelationsAsync(
        bool includeCategory,
        bool includeSubject,
        bool includeTopics,
        bool includeTags
    );
    Task<BrainBlock?> GetBrainBlockAsync(int id);
}
