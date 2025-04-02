using CogLog.App.Contracts.Data.Word;
using CogLog.App.Features.Word.Commands;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public static class WordMapper
{
    public static WordDto ToWordDto(this Word word)
    {
        return new WordDto(
            word.Id,
            word.CreatedAt ?? DateTime.MinValue,
            word.UpdatedAt ?? DateTime.MinValue,
            word.LearnedAt,
            word.Spelling,
            word.Definition,
            word.ExtraInfo,
            word.Language,
            word.PartOfSpeech
        );
    }

    public static List<WordDto> ToWordDtoList(this IEnumerable<Word> words)
    {
        return words.Select(ToWordDto).ToList();
    }

    public static Word ToWord(this CreateWordCommand request)
    {
        return new Word
        {
            LearnedAt = request.LearnedAt,
            Spelling = request.Spelling,
            Definition = request.Definition,
            ExtraInfo = request.ExtraInfo,
            Language = request.Language,
            PartOfSpeech = request.PartOfSpeech,
        };
    }

    public static Word ToWord(this UpdateWordCommand request)
    {
        return new Word
        {
            Id = request.Id,
            LearnedAt = request.LearnedAt,
            Spelling = request.Spelling,
            Definition = request.Definition,
            ExtraInfo = request.ExtraInfo,
            Language = request.Language,
            PartOfSpeech = request.PartOfSpeech,
        };
    }
}
