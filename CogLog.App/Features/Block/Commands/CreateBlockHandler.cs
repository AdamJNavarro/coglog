using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using MediatR;

namespace CogLog.App.Features.Block.Commands;

public class CreateBlockHandler(
    IBlockRepo blockRepo,
    ICategoryRepo categoryRepo,
    ISubjectRepo subjectRepo,
    ITopicRepo topicRepo
) : IRequestHandler<CreateBlockCommand, int>
{
    public async Task<int> Handle(CreateBlockCommand request, CancellationToken cancellationToken)
    {
        var block = new Domain.Block
        {
            Title = request.Title,
            Content = request.Content,
            ExtraContent = request.ExtraContent,
            Url = request.Url,
        };

        if (request.CategoryId.HasValue)
        {
            var categoryExists = await categoryRepo.EntityExistsAsync((int)request.CategoryId);
            if (categoryExists)
            {
                block.CategoryId = (int)request.CategoryId;
            }
        }

        if (request.SubjectId.HasValue)
        {
            var subjectExists = await subjectRepo.EntityExistsAsync((int)request.SubjectId);
            if (subjectExists)
            {
                block.SubjectId = (int)request.SubjectId;
            }
        }

        if (request.TopicIds.Count > 0)
        {
            List<BlockTopic> blockTopics = new List<BlockTopic>();
            // check if topics exist
            // create BlockTopic entities
            foreach (var topicId in request.TopicIds)
            {
                var topicExists = await topicRepo.EntityExistsAsync((int)topicId);
                if (topicExists)
                {
                    blockTopics.Add(new BlockTopic { BlockId = block.Id, TopicId = (int)topicId });
                }
            }

            block.BlockTopics = blockTopics;
        }

        await blockRepo.CreateBlockAsync(block);

        return block.Id;
    }
}
