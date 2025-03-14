using CogLog.UI.Models.Category;
using CogLog.UI.Models.Tag;
using CogLog.UI.Models.Topic;

namespace CogLog.UI.Models.Subject;

public class SubjectDetailsVm
{
    public int Id { get; init; }

    public string Name { get; init; }

    public string? Icon { get; init; }

    public string? Description { get; init; }

    public int CategoryId { get; init; }

    public CategoryMinimalVm Category { get; init; }

    public List<TopicMinimalVm> Topics { get; init; }

    public List<TagMinimalVm> Tags { get; init; }
}
