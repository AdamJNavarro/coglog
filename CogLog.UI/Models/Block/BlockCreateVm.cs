namespace CogLog.UI.Models.Block;

public class BlockCreateVm : BlockBaseWriteVm
{
    public int? CategoryId { get; set; }

    public int? SubjectId { get; set; }
    public List<int> SelectedTopicIds { get; set; } = new List<int>();
    public List<int> SelectedTagIds { get; set; } = new List<int>();
}
