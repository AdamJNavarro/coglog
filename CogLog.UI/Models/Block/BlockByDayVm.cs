namespace CogLog.UI.Models.Block;

public class BlockByDayVm
{
    public DateTime Day { get; set; }
    public int Count { get; set; }
    public List<BlockVm> Blocks { get; set; }
}
