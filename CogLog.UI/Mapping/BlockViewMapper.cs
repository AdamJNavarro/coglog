using CogLog.UI.Models.Block;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public static class BlockViewMapper
{
    public static CreateBlockCommand ToCreateBlockCommand(this CreateBlockVm block)
    {
        return new CreateBlockCommand
        {
            Title = block.Title,
            Content = block.Content,
            ExtraContent = block.ExtraContent,
            Url = block.Url,
            CategoryId = block.CategoryId,
            SubjectId = block.SubjectId,
            TopicIds = block.SelectedTopicIds,
            TagIds = block.SelectedTagIds,
        };
    }
}
