using CogLog.App.Contracts.Data.Block;

namespace CogLog.App.Contracts.Data.Category;

public record CategoryWithBlocksDto(
    int Id,
    string Label,
    string Icon,
    string? Description,
    List<BlockDto> Blocks
);
