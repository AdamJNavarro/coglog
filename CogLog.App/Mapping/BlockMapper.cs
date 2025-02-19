using CogLog.App.Contracts.Data.Block;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class BlockMapper
{
    public static BlockDto ToBlockDto(this Block block)
    {
        return new BlockDto(
            block.Id,
            block.DateAdded ?? DateTime.MinValue,
            block.Title,
            block.Content,
            block.ExtraContent,
            block.Url,
            block.CategoryId,
            block.Category?.ToCategoryDto(),
            block.SubjectId,
            block.Subject?.ToSubjectDto(),
            block.BlockTopics.Select(x => x.Topic.ToTopicDto()).ToList(),
            block.BlockTags.Select(x => x.Tag.ToTagDto()).ToList()
        );
    }

    public static List<BlockDto> ToBlocksDto(this List<Block> blocks)
    {
        return blocks.Select(x => x.ToBlockDto()).ToList();
    }
}
