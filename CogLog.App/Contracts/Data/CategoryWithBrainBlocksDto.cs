namespace CogLog.App.Contracts.Data;

public record CategoryWithBrainBlocksDto(
    int Id,
    string Label,
    string Icon,
    string? Description,
    List<BrainBlockDto> BrainBlocks
);
