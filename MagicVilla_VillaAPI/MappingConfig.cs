using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Models.Dto.Villa;
using MagicVilla_VillaAPI.Models.Dto.VillaNumber;

namespace MagicVilla_VillaAPI;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Villa, VillaDto>();
        CreateMap<VillaDto, Villa>();
        CreateMap<Villa, VillaCreateDto>().ReverseMap(); // does the same thing as the first to mappings
        CreateMap<Villa, VillaUpdateDto>().ReverseMap();
        
        
        CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();
        CreateMap<VillaNumber, VillaNumberCreateDto>().ReverseMap();
        CreateMap<VillaNumber, VillaNumberUpdateDto>().ReverseMap();

    }
}