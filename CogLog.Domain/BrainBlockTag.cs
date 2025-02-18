namespace CogLog.Domain;

public class BrainBlockTag
{
    public required int BrainBlockId { get; set; }
    public BrainBlock BrainBlock { get; set; }
    public required int TagId { get; set; }
    public Tag Tag { get; set; }
}
