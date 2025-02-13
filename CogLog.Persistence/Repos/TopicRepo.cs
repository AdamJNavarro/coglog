using CogLog.App.Contracts.Persistence;
using CogLog.Domain;

namespace CogLog.Persistence.Repos;

public class TopicRepo(AppDbContext dbContext) : GenericRepo<Topic>(dbContext), ITopicRepo;
