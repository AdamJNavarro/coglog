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
            CategoryId = request.CategoryId,
            SubjectId = request.SubjectId,
        };

        if (request.TopicIds.Count > 0)
        {
            List<BlockTopic> blockTopics = [];

            foreach (var topicId in request.TopicIds)
            {
                blockTopics.Add(new BlockTopic { BlockId = block.Id, TopicId = (int)topicId });
            }

            block.BlockTopics = blockTopics;
        }

        if (request.TagIds.Count > 0)
        {
            List<BlockTag> blockTags = [];
            foreach (var tagId in request.TagIds)
            {
                blockTags.Add(new BlockTag { BlockId = block.Id, TagId = (int)tagId });
            }
            block.BlockTags = blockTags;
        }

        await blockRepo.CreateBlockAsync(block);

        return block.Id;
    }
}
