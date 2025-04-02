using CogLog.Domain;
using MediatR;

namespace CogLog.App.Features.Word.Commands;

public record CreateWordCommand(
    DateTime LearnedAt,
    string Spelling,
    string Definition,
    string? ExtraInfo,
    Language Language,
    PartOfSpeech? PartOfSpeech
) : IRequest<int>;
