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

        block.Title = request.Title;
        block.Content = request.Content;
        block.ExtraContent = request.ExtraContent;
        block.Url = request.Url;
        block.SubjectId = request.SubjectId;

        // clear topics and tags
        block.BlockTopics.Clear();
        block.BlockTags.Clear();

        if (request.TopicIds.Count != 0)
        {
            foreach (var topicId in request.TopicIds)
            {
                block.BlockTopics.Add(
                    new BlockTopic { BlockId = block.Id, TopicId = (int)topicId }
                );
            }
        }

        if (request.TagIds.Count != 0)
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
