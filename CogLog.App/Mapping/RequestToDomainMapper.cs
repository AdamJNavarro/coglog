using CogLog.App.Features.Category.Commands;
using CogLog.App.Features.Subject.Commands;
using CogLog.App.Features.Topic.Commands;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class RequestToDomainMapper
{
    public static Category ToCategory(this CreateCategoryCommand request)
    {
        return new Category
        {
            Label = request.Label,
            Icon = request.Icon,
            Description = request.Description,
        };
    }

    public static Category ToCategory(this UpdateCategoryCommand request)
    {
        return new Category
        {
            Id = request.Id,
            Label = request.Label,
            Icon = request.Icon,
            Description = request.Description,
        };
    }

    public static Subject ToSubject(this CreateSubjectCommand request)
    {
        return new Subject
        {
            Label = request.Label,
            Icon = request.Icon,
            Description = request.Description,
            CategoryId = request.CategoryId,
        };
    }

    public static Topic ToTopic(this CreateTopicCommand request)
    {
        return new Topic
        {
            Label = request.Label,
            Icon = request.Icon,
            Description = request.Description,
            SubjectId = request.SubjectId,
        };
    }
}
