using AutoMapper;
using CommonCode.Models.Dtos.Requests;
using CommonCode.Models.Dtos;
using CommonCode.Models.Dtos.Responses;
using CommonCode.Models.Dtos.Identity;
using CommonCode.CommonClasses;

namespace CommonCode.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ServiceDetail, GetServiceRequestDto>().ReverseMap();
            CreateMap<ServiceDetail, GetDiagnosRequestDto>().ReverseMap();
            CreateMap<ServiceDetail, CreateServiceRequestDto>().ReverseMap();
            CreateMap<ServiceDetail, EditDiagnosRequestDto>().ReverseMap();
            CreateMap<ServiceDetail, EditServiceRequestDto>().ReverseMap();
            CreateMap<GetDiagnosResponseDto, GetServiceResponseDto>().ReverseMap();
            CreateMap<GetDiagnosResponseDto, ServiceDto>().ReverseMap();
            CreateMap<GetServiceResponseDto, ServiceDto>().ReverseMap();
            CreateMap<ServiceDetail, ServiceDto>().ReverseMap();
        }
    }
}
