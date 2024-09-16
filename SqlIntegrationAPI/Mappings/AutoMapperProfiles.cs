using AutoMapper;
using SqlIntegrationAPI.Models.Domains;
using SqlIntegrationAPI.Models.Dtos.Requests;
using SqlIntegrationAPI.Models.Dtos;
using SqlIntegrationAPI.Models.Dtos.Responses;

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
        }
    }
}
