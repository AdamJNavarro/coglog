using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using CogLog.Domain.Hierarchy;

namespace CogLog.Persistence.Repos;

public class TopicRepo(AppDbContext dbContext) : GenericRepo<Topic>(dbContext), ITopicRepo;
