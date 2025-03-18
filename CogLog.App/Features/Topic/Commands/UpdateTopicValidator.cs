using CogLog.App.Constants;
using CogLog.App.Contracts.Persistence;
using FluentValidation;

namespace CogLog.App.Features.Topic.Commands;

public class UpdateTopicValidator : AbstractValidator<UpdateTopicCommand>
{
    private readonly ISubjectRepo _subjectRepo;
    private readonly ITopicRepo _topicRepo;

    public UpdateTopicValidator(ITopicRepo topicRepo, ISubjectRepo subjectRepo)
    {
        _subjectRepo = subjectRepo;
        _topicRepo = topicRepo;

        RuleFor(x => x.Id).NotNull().MustAsync(TopicMustExist).WithMessage("Topic does not exist!");

        RuleFor(x => x.SubjectId)
            .NotNull()
            .MustAsync(SubjectMustExist)
            .WithMessage("Subject does not exist!");

        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required")
            .NotNull()
            .MinimumLength(ValidationConstants.Hierarchy.NameMinLength)
            .WithMessage("{PropertyName} must be at least {MinLength} characters");
    }

    private async Task<bool> SubjectMustExist(int id, CancellationToken arg2)
    {
        return await _subjectRepo.EntityExistsAsync(id);
    }

    private async Task<bool> TopicMustExist(int id, CancellationToken arg2)
    {
        return await _topicRepo.EntityExistsAsync(id);
    }
}
