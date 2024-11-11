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

        CreateMap<PublicationPostDto, Publication>()
            .ForMember(dest => dest.Videos, opt => opt.MapFrom(src => MapVideos(src.Videos, src.VideoDetails)));

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

    private List<Video> MapVideos(List<IFormFile> videoFiles, List<VideoDto> videoDetails)
    {
        var videoList = new List<Video>();

        if (videoFiles != null && videoFiles.Count > 0)
        {
            foreach (var file in videoFiles)
            {
                var video = new Video
                {
                    FileName = file.FileName,
                    FileContent = GetFileContent(file),
                    
                };
                videoList.Add(video);
            }
        }

        
        if (videoDetails != null && videoDetails.Count > 0)
        {
            foreach (var detail in videoDetails)
            {
                var video = new Video
                {
                    Title = detail.Title,
                    Description = detail.Description,
                    FileName = detail.FileName
                };
                videoList.Add(video);
            }
        }

        return videoList;
    }
}
