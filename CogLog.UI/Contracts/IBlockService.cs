using CogLog.App.Contracts.Data.Block;
using CogLog.UI.Models.Block;
using CogLog.UI.Models.Shared.Pagination;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Contracts;

public interface IBlockService
{
    Task<PaginationResponseVm<BlockVm>> GetBlocksAsync(BlocksQueryParameters queryParameters);

    Task<List<BlockByDayVm>> GetBlocksByDayAsync();

    Task<BlockDetailsVm> GetBlockDetailsAsync(int id);

    Task<Response<Guid>> CreateBlockAsync(BlockCreateVm block);

    Task<Response<Guid>> UpdateBlockAsync(BlockEditVm block);

    Task<Response<Guid>> DeleteBlockAsync(int id);
}
