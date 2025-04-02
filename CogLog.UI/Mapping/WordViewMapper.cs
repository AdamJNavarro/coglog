using CogLog.UI.Models.Word;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public static class WordViewMapper
{
    public static WordVm ToWordVm(this WordDto word)
    {
        return new WordVm()
        {
            Id = word.Id,
            LearnedAt = word.LearnedAt,
            Spelling = word.Spelling,
            Definition = word.Definition,
            ExtraInfo = word.ExtraInfo,
            Language = (Domain.Language)word.Language,
            PartOfSpeech = (Domain.PartOfSpeech)word.PartOfSpeech,
        };
    }

    public static WordPaginationVm ToWordPaginationVm(this WordDtoPaginationResponse resp)
    {
        return new WordPaginationVm
        {
            Pagination = resp.Pagination.ToPaginationMetadataVm(),
            Data = resp.Data.Select(x => x.ToWordVm()).ToList(),
        };
    }

    public static CreateWordCommand ToCreateWordCommand(this WordCreateVm word)
    {
        return new CreateWordCommand()
        {
            LearnedAt = word.LearnedAt,
            Spelling = word.Spelling,
            Definition = word.Definition,
            ExtraInfo = word.ExtraInfo,
            Language = (Language)word.Language,
            PartOfSpeech = (PartOfSpeech)word.PartOfSpeech,
        };
    }

    public static UpdateWordCommand ToUpdateWordCommand(this WordEditVm word)
    {
        return new UpdateWordCommand()
        {
            Id = word.Id,
            LearnedAt = word.LearnedAt,
            Spelling = word.Spelling,
            Definition = word.Definition,
            ExtraInfo = word.ExtraInfo,
            Language = (Language)word.Language,
            PartOfSpeech = (PartOfSpeech)word.PartOfSpeech,
        };
    }
}
