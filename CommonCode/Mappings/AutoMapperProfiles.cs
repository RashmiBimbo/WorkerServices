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
            CreateMap<ServiceDetail, EditDiagnosRequestDto>().ReverseMap();
            CreateMap<ServiceDetail, PartialServiceDto>().ReverseMap();
            CreateMap<GetDiagnosResponseDto, PartialServiceDto>().ReverseMap();
            CreateMap<GetDiagnosResponseDto, ServiceDto>().ReverseMap();
            CreateMap<PartialServiceDto, ServiceDto>().ReverseMap();
            CreateMap<ServiceDetail, ServiceDto>().ReverseMap();
        }
    }
}
