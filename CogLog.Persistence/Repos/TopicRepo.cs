using CogLog.App.Contracts.Data.Topic;
using CogLog.App.Contracts.Persistence;
using CogLog.App.Mapping;
using CogLog.Domain;
using Microsoft.EntityFrameworkCore;

namespace CogLog.Persistence.Repos;

public class TopicRepo(AppDbContext ctx) : BaseRepo<Topic>(ctx), ITopicRepo
{
    private readonly AppDbContext _ctx = ctx;

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

    public async Task<TopicDetailsDto?> GetTopicDetailsAsync(int id)
    {
        var data = await _ctx.Topics.Include(x => x.Subject).SingleOrDefaultAsync(x => x.Id == id);
        return data.ToTopicDetailsDto();
    }

    public async Task<List<TopicMinimalDto>> GetAllTopicsAsync(int? subjectId = null)
    {
        var query = _ctx.Topics.AsNoTracking();

        if (subjectId.HasValue)
        {
            query = query.Where(x => x.SubjectId == subjectId.Value);
        }

        var topics = await query.ToListAsync();

        return topics.ToTopicMinimalDtoList();
    }
}
