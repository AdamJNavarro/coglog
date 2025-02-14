using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface IBrainBlockRepo : IGenericRepo<BrainBlock>
{
    Task<List<BrainBlock>> GetBrainBlocksWithDetails();
}
