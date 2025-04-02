using CogLog.App.Contracts.Data.Word;
using MediatR;

namespace CogLog.App.Features.Word.Queries;

public record GetWordDetailsQuery(int Id) : IRequest<WordDto>;
