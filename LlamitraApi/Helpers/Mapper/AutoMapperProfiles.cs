using AutoMapper;
using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Models.Dtos.CourseDtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<User, UserPostDto>();


        CreateMap<Publication, PublicationPostDto>();
            


        CreateMap<PublicationPostDto, Publication>()
            .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => MapVideos(src.VideoDetails)));

        CreateMap<Publication, PublicacionGetDto>()
            .ForMember(dest => dest.VideoDetails, opt => opt.MapFrom(src => src.Videos));
            //.ForMember(dest => dest.VideoDetails, opt => opt.MapFrom(src => src.DescriptionProgram))
            //.ForMember(dest => dest.VideoDetails, opt => opt.MapFrom(src => src.Duration))
            //.ForMember(dest => dest.VideoDetails, opt => opt.MapFrom(src => src.DurationWeek))
            //.ForMember(dest => dest.VideoDetails, opt => opt.MapFrom(src => src.Category))
            //.ForMember(dest => dest.VideoDetails, opt => opt.MapFrom(src => src.KnowledgeLevel))
            //.ForMember(dest => dest.VideoDetails, opt => opt.MapFrom(src => src.Favorite))
            //.ForMember(dest => dest.VideoDetails, opt => opt.MapFrom(src => src.Comprado));


        CreateMap<Video, VideoDto>()
            .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath)).ReverseMap();

        CreateMap<PublicationType, PublicationTypePostDto>();
    }

    private List<Video> MapVideos(List<VideoDto> videoDetails)
    {
        if (videoDetails == null)
            return new List<Video>();

        return videoDetails.Select(v => new Video
        {
            Title = v.Title,
            Description = v.Description,
            FilePath = v.FilePath ?? new List<string>()
        }).ToList();
    }


}

