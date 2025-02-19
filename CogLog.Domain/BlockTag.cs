namespace CogLog.Domain;

public class BlockTag
{
    public required int BlockId { get; set; }
    public Block Block { get; set; }
    public required int TagId { get; set; }
    public Tag Tag { get; set; }
}
