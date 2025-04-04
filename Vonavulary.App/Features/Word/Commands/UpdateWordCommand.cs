using MediatR;
using Vonavulary.Domain;

namespace Vonavulary.App.Features.Word.Commands;

public record UpdateWordCommand(
    int Id,
    DateTime LearnedAt,
    string Spelling,
    string Definition,
    string? ExtraInfo,
    Language Language,
    PartOfSpeech? PartOfSpeech
) : IRequest<Unit>;
