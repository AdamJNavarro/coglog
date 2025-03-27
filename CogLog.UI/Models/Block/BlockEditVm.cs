namespace CogLog.UI.Models.Block;

public class BlockEditVm : BlockBaseWriteVm
{
    public int Id { get; init; }
    public DateTime DateLearned { get; set; }

    public int? SubjectId { get; set; }
    public List<int> SelectedTopicIds { get; set; } = new List<int>();
    public List<int> SelectedTagIds { get; set; } = new List<int>();
}
