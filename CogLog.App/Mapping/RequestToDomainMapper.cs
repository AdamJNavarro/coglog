using CogLog.App.Features.Category.Create;
using CogLog.Domain.Hierarchy;

namespace CogLog.App.Mapping;

public static class RequestToDomainMapper
{
    public static Category ToCategory(this CreateCategoryCommand request)
    {
        return new Category { Label = request.Label, Icon = request.Icon };
    }
}
