using CogLog.Domain;
using MediatR;

namespace CogLog.App.Features.BrainBlock.Update;

public class UpdateBrainBlockCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public DateTime DateAdded { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public string? AdditionalContext { get; set; } = string.Empty;

    public string? Url { get; set; } = string.Empty;
}
