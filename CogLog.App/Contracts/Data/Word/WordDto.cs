using CogLog.Domain;

namespace CogLog.App.Contracts.Data.Word;

public record WordDto(
    int Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    DateTime LearnedAt,
    string Spelling,
    string Definition,
    string? ExtraInfo,
    Language Language,
    PartOfSpeech? PartOfSpeech
);
