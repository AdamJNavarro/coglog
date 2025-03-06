namespace CogLog.App.Contracts.Data.Block;

public record BlocksByDayDto(DateTime Day, int Count, List<BlockDto> Blocks);
