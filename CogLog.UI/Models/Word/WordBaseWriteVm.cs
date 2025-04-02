using System.ComponentModel.DataAnnotations;
using CogLog.Domain;

namespace CogLog.UI.Models.Word;

public class WordBaseWriteVm
{
    [Required]
    public DateTime LearnedAt { get; set; }

    [Required]
    public string Spelling { get; set; }

    [Required]
    public string Definition { get; set; }

    public string? ExtraInfo { get; set; }

    [Required]
    [EnumDataType(typeof(Language), ErrorMessage = "Please select valid language.")]
    public Language Language { get; set; }

    [EnumDataType(typeof(PartOfSpeech), ErrorMessage = "Please select valid part of speech.")]
    public PartOfSpeech PartOfSpeech { get; set; }
}
