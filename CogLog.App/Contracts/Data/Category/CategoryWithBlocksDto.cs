using CogLog.App.Contracts.Data.Block;

namespace CogLog.App.Contracts.Data.Category;

public record CategoryWithBlocksDto(
    int Id,
    string Name,
    string? Icon,
    string? Description,
    List<BlockDto> Blocks
);
