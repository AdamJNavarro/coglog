using CogLog.App.Contracts.Data;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class DomainToDtoMapper
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new CategoryDto(category.Id, category.Label, category.Icon, category.Description);
    }

    public static List<CategoryDto> ToCategoryDtos(this List<Category> categories)
    {
        return categories.Select(x => x.ToCategoryDto()).ToList();
    }

    public static CategoryWithSubjectsDto ToCategoryWithSubjectsDto(this Category category)
    {
        return new CategoryWithSubjectsDto(
            category.Id,
            category.Label,
            category.Icon,
            category.Description,
            category.Subjects.Select(x => x.ToSubjectDto()).ToList()
        );
    }

    public static CategoryWithBrainBlocksDto ToCategoryWithBrainBlocksDto(this Category category)
    {
        return new CategoryWithBrainBlocksDto(
            category.Id,
            category.Label,
            category.Icon,
            category.Description,
            category.BrainBlocks.Select(x => x.ToBrainBlockDto()).ToList()
        );
    }

    public static SubjectDto ToSubjectDto(this Subject subject)
    {
        return new SubjectDto(
            subject.Id,
            subject.Label,
            subject.Icon,
            subject.Description,
            subject.CategoryId
        );
    }

    public static TagDto ToTagDto(this Tag tag)
    {
        return new TagDto(tag.Id, tag.Label, tag.Icon, tag.SubjectId);
    }

    public static BrainBlockDto ToBrainBlockDto(this BrainBlock brainBlock)
    {
        return new BrainBlockDto(
            brainBlock.Id,
            brainBlock.DateAdded ?? DateTime.MinValue,
            brainBlock.Title,
            brainBlock.Content,
            brainBlock.ExtraContent,
            brainBlock.Url,
            brainBlock.CategoryId,
            brainBlock.Category?.ToCategoryDto(),
            brainBlock.SubjectId,
            brainBlock.Subject?.ToSubjectDto()
        );
    }
}
