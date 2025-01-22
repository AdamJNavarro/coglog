using CogLog.UI.Models;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface IBrainBlockService
{
    Task<List<BrainBlockVm>> GetBrainBlocks();

    Task<BrainBlockVm> GetBrainBlockById(int id);
    Task<Response<Guid>> CreateBrainBlock(CreateBrainBlockVm brainBlock);

    Task<Response<Guid>> EditBrainBlock(int id, BrainBlockVm brainBlock);

    Task<Response<Guid>> DeleteBrainBlock(int id);
}
