namespace CogLog.UI.Models.Block;

public class CreateBlockVm
{
    public required string Title { get; init; }

    public required string Content { get; init; }

    public string? ExtraContent { get; init; }

    public string? Url { get; init; }
}
