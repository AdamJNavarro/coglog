using CogLog.Domain;

namespace CogLog.UI.Models.Word;

public class WordVm
{
    public int Id { get; init; }

    public DateTime LearnedAt { get; set; }

    public string Spelling { get; set; }

    public string Definition { get; set; }

    public string? ExtraInfo { get; set; }

    public Language Language { get; set; }

    public string LanguageDisplay =>
        Language switch
        {
            Language.English => "🇺🇸",
            Language.Japanese => "🇯🇵",
            Language.French => "🇫🇷",
            _ => "",
        };

    public PartOfSpeech PartOfSpeech { get; set; }

    public string PartOfSpeechDisplay =>
        PartOfSpeech switch
        {
            PartOfSpeech.Adjective => "adj",
            PartOfSpeech.Adverb => "adv",
            PartOfSpeech.Conjunction => "conj",
            PartOfSpeech.Interjection => "intj",
            PartOfSpeech.Noun => "noun",
            PartOfSpeech.Phrase => "phrase",
            PartOfSpeech.Pronoun => "pron",
            PartOfSpeech.Verb => "verb",
        };

    public string CapitalizedSpelling =>
        System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
            Spelling?.ToLower() ?? string.Empty
        );
}
