using AutoMapper;
using CogLog.UI.Models;
using CogLog.UI.Services.Base;

namespace CogLog.UI.Mapping;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<BrainBlockDto, BrainBlockVm>().ReverseMap();
        CreateMap<BrainBlockDetailsDto, BrainBlockVm>().ReverseMap();
        CreateMap<CreateBrainBlockCommand, CreateBrainBlockVm>().ReverseMap();
        CreateMap<UpdateBrainBlockCommand, BrainBlockVm>().ReverseMap();
        CreateMap<TopicDto, TopicVm>().ReverseMap();
        CreateMap<CreateTopicCommand, CreateTopicVm>().ReverseMap();
        CreateMap<UpdateTopicCommand, TopicVm>().ReverseMap();
    }
}
