using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class TopicRepo(AppDbContext ctx) : BaseRepo<Topic>(ctx), ITopicRepo
{
    private readonly AppDbContext _ctx = ctx;

    public async Task<List<Topic>> GetTopicsBySubjectAsync(int subjectId)
    {
        return await _ctx.Topics.AsNoTracking().Where(x => x.SubjectId == subjectId).ToListAsync();
    }

    public async Task CreateTopicAsync(Topic topic)
    {
        await _ctx.Topics.AddAsync(topic);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateTopicAsync(Topic topic)
    {
        _ctx.Entry(topic).State = EntityState.Modified;
        await _ctx.SaveChangesAsync();
        ;
    }

    public async Task DeleteTopicAsync(Topic topic)
    {
        _ctx.Topics.Remove(topic);
        await _ctx.SaveChangesAsync();
    }

    public async Task<Topic?> GetTopicAsync(int id)
    {
        return await _ctx.Topics.AsNoTracking().SingleOrDefaultAsync(q => q.Id == id);
    }
}
