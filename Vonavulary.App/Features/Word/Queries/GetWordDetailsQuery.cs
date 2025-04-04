using MediatR;
using Vonavulary.App.Contracts.Data.Word;

namespace Vonavulary.App.Features.Word.Queries;

public record GetWordDetailsQuery(int Id) : IRequest<WordDto>;
