using MediatR;
using Vonavulary.Domain;

namespace Vonavulary.App.Features.Word.Commands;

public record CreateWordCommand(
    DateTime LearnedAt,
    string Spelling,
    string Definition,
    string? ExtraInfo,
    Language Language,
    PartOfSpeech? PartOfSpeech
) : IRequest<int>;
