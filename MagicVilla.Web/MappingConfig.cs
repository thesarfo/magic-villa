using AutoMapper;
using MagicVilla.Web.Models;
using MagicVilla.Web.Models.Dto.Villa;
using MagicVilla.Web.Models.Dto.VillaNumber;

namespace MagicVilla.Web;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<VillaDto, VillaCreateDto>().ReverseMap(); 
        CreateMap<VillaDto, VillaUpdateDto>().ReverseMap();
        
        CreateMap<VillaNumberDto, VillaNumberCreateDto>().ReverseMap();
        CreateMap<VillaNumberDto, VillaNumberUpdateDto>().ReverseMap();

    }   
}