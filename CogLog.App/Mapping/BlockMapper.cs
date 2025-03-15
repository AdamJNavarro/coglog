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
            block.SubjectId,
            block.Subject?.ToSubjectMinimalDto(),
            block.BlockTopics.Select(x => x.Topic.ToTopicMinimalDto()).ToList(),
            block.BlockTags.Select(x => x.Tag.ToTagMinimalDto()).ToList()
        );
    }

    public static List<BlockDto> ToBlockDtoList(this List<Block> blocks)
    {
        return blocks.Select(x => x.ToBlockDto()).ToList();
    }
}
