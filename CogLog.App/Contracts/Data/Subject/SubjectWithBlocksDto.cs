using CogLog.App.Contracts.Data.Block;

namespace CogLog.App.Contracts.Data;

public record SubjectWithBlocksDto(
    int Id,
    string Name,
    string? Icon,
    string? Description,
    List<BlockDto> Blocks
);
