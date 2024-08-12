using AutoMapper;
using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models.Dtos.UserDtos;

namespace LlamitraApi.Helpers.Mapper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserPostDto>();
            CreateMap<Publication, PublicationPostDto>();
            CreateMap<PublicationType, PublicationTypePostDto>();
           
        }
    }
}
