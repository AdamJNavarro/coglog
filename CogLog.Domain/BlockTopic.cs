namespace CogLog.Domain;

public class BlockTopic
{
    public required int BlockId { get; set; }
    public Block Block { get; set; }
    public required int TopicId { get; set; }
    public Topic Topic { get; set; }
}
