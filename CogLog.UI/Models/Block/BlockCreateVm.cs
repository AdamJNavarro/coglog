namespace CogLog.UI.Models.Block;

public class BlockCreateVm
{
    public string Title { get; set; }

    public string Content { get; set; }

    public string? ExtraContent { get; set; }

    public string? Url { get; set; }

    public int? CategoryId { get; set; }

    public int? SubjectId { get; set; }
    public List<int> SelectedTopicIds { get; set; } = new List<int>();
    public List<int> SelectedTagIds { get; set; } = new List<int>();
}
