using CogLog.App.Contracts.Persistence;
using CogLog.Domain;

namespace CogLog.Persistence.Repos;

public class BrainBlockRepo(AppDbContext dbContext)
    : GenericRepo<BrainBlock>(dbContext),
        IBrainBlockRepo;
