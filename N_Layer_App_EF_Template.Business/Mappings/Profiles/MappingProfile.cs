using AutoMapper;
using N_Layer_App_EF_Template.Business.DTOs.ClaimDTOs;
using N_Layer_App_EF_Template.Business.DTOs.RoleDTOs;
using N_Layer_App_EF_Template.Domain.Entities.Concretes;

namespace N_Layer_App_EF_Template.Business.Mappings.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Role, RoleDto>().ForMember(dest => dest.Claims, opt => opt.MapFrom(src => src.Claims));
        CreateMap<RoleDto, Role>().ForMember(dest => dest.Claims, opt => opt.Ignore());


        CreateMap<Claim, ClaimDto>();
        CreateMap<ClaimDto, Claim>();
    }
}
