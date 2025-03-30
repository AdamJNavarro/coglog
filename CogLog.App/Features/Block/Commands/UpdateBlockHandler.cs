using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.Domain;
using MediatR;

namespace CogLog.App.Features.Block.Commands;

public class UpdateBlockHandler(IBlockRepo blockRepo) : IRequestHandler<UpdateBlockCommand, Unit>
{
    public async Task<Unit> Handle(UpdateBlockCommand request, CancellationToken cancellationToken)
    {
        var block = await blockRepo.GetBlockAsync(request.Id, true, true);

        if (block == null)
        {
            throw new NotFoundException(nameof(Block), request.Id);
        }

        block.LearnedAt = request.LearnedAt;
        block.Title = request.Title;
        block.Content = request.Content;
        block.ExtraContent = request.ExtraContent;
        block.Url = request.Url;
        block.SubjectId = request.SubjectId;

        var selectedIds = string.Join(", ", request.TopicIds);
        Console.WriteLine($"Handler Selected IDs: {selectedIds}");

        var topicsToRemove = block
            .BlockTopics.Where(bt => !request.TopicIds.Contains(bt.TopicId))
            .ToList();

        foreach (var blockTopic in topicsToRemove)
        {
            block.BlockTopics.Remove(blockTopic);
        }

        // Add new topics that aren't already associated with the book
        var existingTopicIds = block.BlockTopics.Select(bt => bt.TopicId).ToList();
        var topicsToAdd = request
            .TopicIds.Where(id => !existingTopicIds.Contains(id))
            .Select(id => new BlockTopic { BlockId = request.Id, TopicId = id })
            .ToList();

        foreach (var blockTopic in topicsToAdd)
        {
            block.BlockTopics.Add(blockTopic);
        }

        // clear topics and tags
        // block.BlockTopics.Clear();
        block.BlockTags.Clear();

        // if (request.TopicIds.Count > 0)
        // {
        //     List<BlockTopic> blockTopics = [];
        //
        //     foreach (var topicId in request.TopicIds)
        //     {
        //         blockTopics.Add(new BlockTopic { BlockId = block.Id, TopicId = (int)topicId });
        //     }
        //     block.BlockTopics = blockTopics;
        // }

        if (request.TagIds.Count > 0)
        {
            foreach (var tagId in request.TagIds)
            {
                block.BlockTags.Add(new BlockTag { BlockId = block.Id, TagId = (int)tagId });
            }
        }

        await blockRepo.UpdateBlockAsync(block);
        return Unit.Value;
    }
}
