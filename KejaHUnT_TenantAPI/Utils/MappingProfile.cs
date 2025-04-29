using AutoMapper;
using KejaHUnT_TenantAPI.Models.Domain;
using KejaHUnT_TenantAPI.Models.Dto;

namespace KejaHUnT_TenantAPI.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tenant, CreateTenantRequestDto>().ReverseMap();
            CreateMap<Tenant, TenantDto>().ReverseMap();
        }

    }
}
