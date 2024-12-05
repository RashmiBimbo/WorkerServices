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
            //CreateMap<ServiceDetail, PartialServiceDto>().ReverseMap();
            CreateMap<GetDiagnosResponseDto, PartialServiceDto>().ReverseMap();
            CreateMap<GetDiagnosResponseDto, ServiceDto>().ReverseMap();
            CreateMap<PartialServiceDto, ServiceDto>().ReverseMap();

            CreateMap<PartialServiceDto, ServiceDetail>()
                 .ForMember(dest => dest.Columns,
                     opt => opt.MapFrom(src =>
                         string.IsNullOrEmpty(src.Columns)
                             ? new List<Column>()
                             : JsonConvert.DeserializeObject<List<Column>>(src.Columns)))
                 .ReverseMap()
                 .ForMember(dest => dest.Columns,
                     opt => opt.MapFrom(src =>
                         src.Columns != null
                             ? JsonConvert.SerializeObject(src.Columns)
                             : null));

            CreateMap<ServiceDto, ServiceDetail>()
                .ForMember(dest => dest.Columns,
                    opt => opt.MapFrom(src =>
                        string.IsNullOrEmpty(src.Columns)
                            ? new List<Column>()
                            : JsonConvert.DeserializeObject<List<Column>>(src.Columns)))
                .ReverseMap()
                .ForMember(dest => dest.Columns,
                    opt => opt.MapFrom(src =>
                        src.Columns != null
                            ? JsonConvert.SerializeObject(src.Columns)
                            : null));
            //map.ForAllMembers(dest => dest.UseDestinationValue());
        }
    }
}
