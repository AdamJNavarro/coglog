using AutoMapper;
using CogLog.App.Features.Topic.Create;
using CogLog.App.Features.Topic.Get;
using CogLog.App.Features.Topic.Update;
using CogLog.Domain;
using CogLog.Domain.Hierarchy;

namespace CogLog.App.Mapping;

public class TopicProfile : Profile
{
    public TopicProfile()
    {
        CreateMap<TopicDto, Topic>().ReverseMap();
        CreateMap<CreateTopicCommand, Topic>();
        CreateMap<UpdateTopicCommand, Topic>();
    }
}
