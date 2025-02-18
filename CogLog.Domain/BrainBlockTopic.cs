namespace CogLog.Domain;

public class BrainBlockTopic
{
    public required int BrainBlockId { get; set; }
    public BrainBlock BrainBlock { get; set; }
    public required int TopicId { get; set; }
    public Topic Topic { get; set; }
}
