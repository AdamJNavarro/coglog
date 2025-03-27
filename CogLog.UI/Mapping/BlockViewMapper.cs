using CogLog.UI.Models.Block;
using CogLog.UI.Models.Shared.Pagination;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public static class BlockViewMapper
{
    public static BlockVm ToBlockVm(this BlockDto block)
    {
        return new BlockVm
        {
            Id = block.Id,
            LearnedAt = block.LearnedAt,
            Title = block.Title,
            Content = block.Content,
            ExtraContent = block.ExtraContent,
            Url = block.Url,
            SubjectId = block.SubjectId,
            Subject = block.Subject?.ToSubjectMinimalVm(),
            Topics = block.Topics.Select(x => x.ToTopicMinimalVm()).ToList(),
            Tags = block.Tags.Select(x => x.ToTagMinimalVm()).ToList(),
        };
    }

    public static BlockDetailsVm ToBlockDetailsVm(this BlockDetailsDto block)
    {
        return new BlockDetailsVm()
        {
            Id = block.Id,
            LearnedAt = block.LearnedAt,
            Title = block.Title,
            Content = block.Content,
            ExtraContent = block.ExtraContent,
            Url = block.Url,
            SubjectId = block.SubjectId,
            Subject = block.Subject?.ToSubjectMinimalVm(),
            Topics = block.Topics.Select(x => x.ToTopicMinimalVm()).ToList(),
            Tags = block.Tags.Select(x => x.ToTagMinimalVm()).ToList(),
        };
    }

    public static BlockPaginationVm ToPaginationBlockVm(this BlockDtoPaginationResponse resp)
    {
        return new BlockPaginationVm
        {
            Pagination = resp.Pagination.ToPaginationMetadataVm(),
            Data = resp.Data.Select(x => x.ToBlockVm()).ToList(),
        };
    }

    public static List<BlockByDayVm> ToBlockByDayVmList(this IEnumerable<BlocksByDayDto> groups)
    {
        return groups
            .Select(x => new BlockByDayVm
            {
                Day = x.Day,
                Count = x.Count,
                Blocks = x.Blocks.Select(x => x.ToBlockVm()).ToList(),
            })
            .ToList();
    }

    public static CreateBlockCommand ToCreateBlockCommand(this BlockCreateVm block)
    {
        return new CreateBlockCommand
        {
            LearnedAt = block.LearnedAt,
            Title = block.Title,
            Content = block.Content,
            ExtraContent = block.ExtraContent,
            Url = block.Url,
            SubjectId = block.SubjectId,
            TopicIds = block.SelectedTopicIds,
            TagIds = block.SelectedTagIds,
        };
    }

    public static UpdateBlockCommand ToUpdateBlockCommand(this BlockEditVm block)
    {
        return new UpdateBlockCommand()
        {
            Id = block.Id,
            LearnedAt = block.LearnedAt,
            Title = block.Title,
            Content = block.Content,
            ExtraContent = block.ExtraContent,
            Url = block.Url,
            SubjectId = block.SubjectId,
            TopicIds = block.SelectedTopicIds,
            TagIds = block.SelectedTagIds,
        };
    }
}
