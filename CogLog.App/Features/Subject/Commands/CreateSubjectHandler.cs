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
        var validator = new CreateSubjectValidator(categoryRepo);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            throw new BadRequestException("Invalid Subject", validationResult);
        }

        var incomingSubject = request.ToSubject();

        await subjectRepo.CreateSubjectAsync(incomingSubject);
        return incomingSubject.Id;
    }
}
