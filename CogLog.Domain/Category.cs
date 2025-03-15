using CogLog.Domain.Shared;

namespace CogLog.Domain;

public class Category : BaseHierarchy
{
    public List<Subject> Subjects { get; init; } = [];
}
