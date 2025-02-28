using AutoMapper;
using CogLog.UI.Models.Block;
using CogLog.UI.Models.Topic;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<BlockDto, BlockVm>().ReverseMap();
        CreateMap<CreateBlockCommand, CreateBlockVm>().ReverseMap();
        CreateMap<TopicDto, TopicVm>().ReverseMap();
        CreateMap<CreateTopicCommand, CreateTopicVm>().ReverseMap();
        CreateMap<UpdateTopicCommand, TopicVm>().ReverseMap();
    }
}
