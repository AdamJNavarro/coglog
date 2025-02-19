using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class BrainBlockTopicRepo(AppDbContext ctx) : IBrainBlockTopicRepo
{
    public async Task CreateBrainBlockTopicAsync(BrainBlockTopic brainBlockTopic)
    {
        await ctx.BrainBlockTopics.AddAsync(brainBlockTopic);
        await ctx.SaveChangesAsync();
    }

    public async Task CreateBrainBlockTopicsAsync(List<BrainBlockTopic> brainBlockTopics)
    {
        await ctx.BrainBlockTopics.AddRangeAsync(brainBlockTopics);
        await ctx.SaveChangesAsync();
    }

    public async Task<bool> EntityExistsAsync(int brainBlockId, int topicId)
    {
        return await ctx.BrainBlockTopics.AnyAsync(q =>
            q.BrainBlockId == brainBlockId && q.TopicId == topicId
        );
    }
}
