﻿using AutoMapper;
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

        
        CreateMap<Publication, PublicationPostDto>()
            .ForMember(dest => dest.FilePaths, opt => opt.Ignore()) 
            .ReverseMap();

        CreateMap<PublicationPostDto, Publication>()
            .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => MapVideos(src.VideoDetails)));

        CreateMap<Publication, PublicacionGetDto>()
            .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => src.Videos));

        CreateMap<Video, VideoDto>()
            .ForMember(dest => dest.FilePath, opt => opt.MapFrom(src => src.FilePath));

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

