using AutoMapper;
using CogLog.App.Features.BrainBlock.Create;
using CogLog.App.Features.BrainBlock.Get;
using CogLog.App.Features.BrainBlock.GetById;
using CogLog.App.Features.BrainBlock.Update;
using CogLog.Domain;

namespace CogLog.App.Mapping;

public class BrainBlockProfile : Profile
{
    public BrainBlockProfile()
    {
        CreateMap<BrainBlockDto, BrainBlock>().ReverseMap();
        CreateMap<BrainBlock, BrainBlockDetailsDto>();
        CreateMap<CreateBrainBlockCommand, BrainBlock>();
        CreateMap<UpdateBrainBlockCommand, BrainBlock>();
    }
}
