using AutoMapper;
using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models.Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using System.IO;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        
        CreateMap<User, UserPostDto>();

        
        CreateMap<Publication, PublicationPostDto>()
            .ForMember(dest => dest.Videos, opt => opt.Ignore()) 
            .ReverseMap();

        
        CreateMap<Publication, PublicacionGetDto>()
            .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.Videos));

        
        CreateMap<Video, VideoGetDto>();

        
        CreateMap<IFormFile, Video>()
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName)) 
            .ForMember(dest => dest.FileContent, opt => opt.MapFrom(src => GetFileContent(src))); 

        
        CreateMap<PublicationType, PublicationTypePostDto>();
    }

    
    private byte[] GetFileContent(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}
