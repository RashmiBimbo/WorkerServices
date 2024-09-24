using AutoMapper;
using SqlIntegrationAPI.Models.Domains;
using CommonCode.Models.Dtos.Requests;
using CommonCode.Models.Dtos;
using CommonCode.Models.Dtos.Responses;
using SqlIntegrationAPI.Models.Domains.Identity;
using CommonCode.Models.Dtos.Identity;

namespace SqlIntegrationAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DbService, CreateServiceRequestDto>().ReverseMap();
            CreateMap<DbService, EditServiceRequestDto>().ReverseMap();
            CreateMap<DbService, EditDiagnosRequestDto>().ReverseMap();
            CreateMap<DbService, ServiceDto>().ReverseMap();
            CreateMap<DbService, GetServiceResponseDto>().ReverseMap();
            CreateMap<DbService, GetDiagnosResponseDto>().ReverseMap();
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, AppUserDto>().ReverseMap();
        }
    }
}
