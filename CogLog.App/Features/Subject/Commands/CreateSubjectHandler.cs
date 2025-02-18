using CogLog.App.Contracts.Persistence;
using CogLog.App.Exceptions;
using CogLog.App.Mapping;
using MediatR;

namespace CogLog.App.Features.Subject.Commands;

public class CreateSubjectHandler(ISubjectRepo subjectRepo, ICategoryRepo categoryRepo)
    : IRequestHandler<CreateSubjectCommand, int>
{
    public async Task<int> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        var categoryExists = await categoryRepo.EntityExistsAsync(request.CategoryId);

        if (!categoryExists)
        {
            throw new NotFoundException(nameof(Category), request.CategoryId);
        }

        var incomingSubject = request.ToSubject();

        await subjectRepo.CreateSubjectAsync(incomingSubject);
        return incomingSubject.Id;
    }
}
