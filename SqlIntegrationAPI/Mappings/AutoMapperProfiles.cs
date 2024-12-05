using AutoMapper;
using SqlIntegrationAPI.Models.Domains;
using CommonCode.Models.Dtos.Requests;
using CommonCode.Models.Dtos;
using CommonCode.Models.Dtos.Responses;
using SqlIntegrationAPI.Models.Domains.Identity;
using CommonCode.Models.Dtos.Identity;
using Newtonsoft.Json;

namespace SqlIntegrationAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DbService, EditDiagnosRequestDto>().ReverseMap();
            CreateMap<DbService, ServiceDto>().ReverseMap();
            CreateMap<DbService, PartialServiceDto>().ReverseMap();
            CreateMap<DbService, GetDiagnosResponseDto>().ReverseMap();
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, AppUserDto>().ReverseMap();

            //CreateMap<DbService, ServiceDto>()
            //    .ForMember(dest => dest.Columns,
            //        opt => opt.MapFrom(src =>
            //            string.IsNullOrEmpty(src.Columns)
            //                ? new List<Column>()
            //                : JsonConvert.DeserializeObject<List<Column>>(src.Columns)))
            //    .ReverseMap()
            //    .ForMember(dest => dest.Columns,
            //        opt => opt.MapFrom(src =>
            //            src.Columns != null
            //                ? JsonConvert.SerializeObject(src.Columns)
            //                : null));


            //CreateMap<DbService, PartialServiceDto>()
            //    .ForMember(dest => dest.Columns,
            //        opt => opt.MapFrom(src =>
            //            string.IsNullOrEmpty(src.Columns)
            //                ? new List<Column>()
            //                : JsonConvert.DeserializeObject<List<Column>>(src.Columns)))
            //    .ReverseMap()
            //    .ForMember(dest => dest.Columns,
            //        opt => opt.MapFrom(src =>
            //            src.Columns != null
            //                ? JsonConvert.SerializeObject(src.Columns)
            //                : null));
        }
    }
}
