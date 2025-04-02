using CogLog.Domain;
using MediatR;

namespace CogLog.App.Features.Word.Commands;

public record UpdateWordCommand(
    int Id,
    DateTime LearnedAt,
    string Spelling,
    string Definition,
    string? ExtraInfo,
    Language Language,
    PartOfSpeech? PartOfSpeech
) : IRequest<Unit>;
