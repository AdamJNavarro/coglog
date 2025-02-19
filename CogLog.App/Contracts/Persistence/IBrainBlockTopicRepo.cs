using CogLog.Domain;

namespace CogLog.App.Contracts.Persistence;

public interface IBrainBlockTopicRepo
{
    Task CreateBrainBlockTopicAsync(BrainBlockTopic brainBlockTopic);

    Task CreateBrainBlockTopicsAsync(List<BrainBlockTopic> brainBlockTopics);
}
