﻿using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using AutoMapper;
using LlamitraApi.Repository;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LlamitraApi.Services
{
    public class PublicationServices : IPublicationServices
    {
        private readonly IPublicationRepository _PublicationRepository;
        private readonly IMapper _mapper;
        private readonly ProyectoIContext _dbContext;

        public PublicationServices(IPublicationRepository publicationRepository, IMapper mapper, ProyectoIContext dbContext)
        {
            _PublicationRepository = publicationRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task SavePublicationAsync(PublicationPostDto publicationDto)
        {
            var publication = _mapper.Map<Publication>(publicationDto);
            publication.Videos = new List<Video>();

            if (publicationDto.VideoDetails != null && publicationDto.VideoDetails.Count > 0)
            {
                foreach (var videoDetail in publicationDto.VideoDetails)
                {
                    var video = new Video
                    {
                        FilePath = videoDetail.FilePath,
                    };

                    publication.Videos.Add(video);
                }
            }

            publication.DescriptionProgram = publicationDto.DescriptionProgram;
            publication.Duration = publicationDto.Duration;
            publication.DurationWeek = publicationDto.DurationWeek;
            publication.Category = publicationDto.Category;
            publication.KnowledgeLevel = publicationDto.KnowledgeLevel;
            publication.Favorite = publicationDto.Favorite;
            publication.Comprado = publicationDto.Comprado;

            _dbContext.Publications.Add(publication);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreatePublication(PublicationPostDto publicationDto)
        {
            var publication = new Publication()
            {
                IdType = publicationDto.IdType,
                IdUser = publicationDto.IdUser,
                Professor = publicationDto.Professor,
                Price = publicationDto.Price,
                Title = publicationDto.Title,
                Description = publicationDto.Description,
                DescriptionProgram = publicationDto.DescriptionProgram,
                Duration = publicationDto.Duration,
                DurationWeek = publicationDto.DurationWeek,
                Category = publicationDto.Category,
                KnowledgeLevel = publicationDto.KnowledgeLevel,
                Favorite = publicationDto.Favorite,
                Comprado = publicationDto.Comprado,
                Videos = new List<Video>()
            };

            if (publicationDto.VideoDetails != null && publicationDto.VideoDetails.Count > 0)
            {
                for (int i = 0; i < publicationDto.VideoDetails.Count; i++)
                {
                    var videoDetail = publicationDto.VideoDetails[i];

                    var video = new Video
                    {
                        FileName = videoDetail.FileName,
                        FilePath = new List<string>(),
                        Title = videoDetail.Title,
                        Description = videoDetail.Description
                    };

                    publication.Videos.Add(video);
                }
            }

            await _PublicationRepository.AddPublication(publication);
        }

        public async Task<List<PublicacionGetDto>> GetAllPublicationsAsync()
        {
            var publications = await _PublicationRepository.GetAllPublicationWithVideos();
            var publicationsDtos = _mapper.Map<List<PublicacionGetDto>>(publications);
            return publicationsDtos;
        }

        public async Task<List<PublicacionGetDto>> GetAll()
        {
            var publications = await _PublicationRepository.GetAllPublicationWithVideos();
            var publicationsDtos = _mapper.Map<List<PublicacionGetDto>>(publications);
            return publicationsDtos;
        }

        public async Task<PublicacionGetDto> GetPublicationWithVideosById(int id)
        {
            var publication = await _PublicationRepository.GetPublicationById(id);

            if (publication == null)
            {
                throw new KeyNotFoundException("Publicación no encontrada.");
            }

            var publicationDto = _mapper.Map<PublicacionGetDto>(publication);

            return publicationDto;
        }

        public async Task<List<PublicacionGetDto>> GetRandomList()
        {
            var publicationsDtos = new List<PublicacionGetDto>();
            var publications = await _PublicationRepository.GetAllPublication();

            _mapper.Map(publications, publicationsDtos);

            var rng = new Random();
            publicationsDtos = publicationsDtos.OrderBy(x => rng.Next()).ToList();

            return publicationsDtos;
        }

        public async Task<Publication> GetById(int id)
        {
            return await _PublicationRepository.GetPublicationById(id);
        }

        public Task UpdatePublication(Publication publication)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePublication(Publication publication)
        {
            await _PublicationRepository.DeletePublication(publication);
        }
    }
}
