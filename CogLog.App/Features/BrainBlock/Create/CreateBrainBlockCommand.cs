using CogLog.Domain;
using MediatR;

namespace CogLog.App.Features.BrainBlock.Create;

public record CreateBrainBlockCommand(
    string Title,
    string Content,
    string? AdditionalContext,
    BrainBlockVariantEnum Variant
) : IRequest<int>;
