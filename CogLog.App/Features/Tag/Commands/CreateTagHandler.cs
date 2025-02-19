using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Tag.Commands;

public class CreateTagHandler(ITagRepo tagRepo, ISubjectRepo subjectRepo)
    : IRequestHandler<CreateTagCommand, int>
{
    public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var subjectExists = await subjectRepo.EntityExistsAsync(request.SubjectId);
        if (!subjectExists)
        {
            throw new NotFoundException(nameof(Subject), request.SubjectId);
        }

        var incomingTag = request.ToTag();
        await tagRepo.CreateTagAsync(incomingTag);
        return incomingTag.Id;
    }
}
