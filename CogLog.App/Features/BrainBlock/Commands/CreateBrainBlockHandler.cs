using CogLog.App.Contracts.Persistence;
using CogLog.Domain;
using MediatR;

namespace CogLog.App.Features.BrainBlock.Commands;

public class CreateBrainBlockHandler(
    IBrainBlockRepo brainBlockRepo,
    ICategoryRepo categoryRepo,
    ISubjectRepo subjectRepo,
    ITopicRepo topicRepo
) : IRequestHandler<CreateBrainBlockCommand, int>
{
    public async Task<int> Handle(
        CreateBrainBlockCommand request,
        CancellationToken cancellationToken
    )
    {
        var brainBlock = new Domain.BrainBlock
        {
            Title = request.Title,
            Content = request.Content,
            ExtraContent = request.ExtraContent,
            Url = request.Url,
        };

        if (request.CategoryId.HasValue)
        {
            var categoryExists = await categoryRepo.EntityExistsAsync((int)request.CategoryId);
            if (categoryExists)
            {
                brainBlock.CategoryId = (int)request.CategoryId;
            }
        }

        if (request.SubjectId.HasValue)
        {
            var subjectExists = await subjectRepo.EntityExistsAsync((int)request.SubjectId);
            if (subjectExists)
            {
                brainBlock.SubjectId = (int)request.SubjectId;
            }
        }

        if (request.TopicIds.Count > 0)
        {
            List<BrainBlockTopic> brainBlockTopics = new List<BrainBlockTopic>();
            // check if topics exist
            // create BrainBlockTopic entities
            foreach (var topicId in request.TopicIds)
            {
                var topicExists = await topicRepo.EntityExistsAsync((int)topicId);
                if (topicExists)
                {
                    brainBlockTopics.Add(
                        new BrainBlockTopic { BrainBlockId = brainBlock.Id, TopicId = (int)topicId }
                    );
                }
            }

            brainBlock.BrainBlockTopics = brainBlockTopics;
        }

        await brainBlockRepo.CreateBrainBlockAsync(brainBlock);

        return brainBlock.Id;
    }
}
