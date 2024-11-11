using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using AutoMapper;
using LlamitraApi.Repository;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Microsoft.EntityFrameworkCore;

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



        public async Task SavePublicationAsync(PublicationPostDto publicationDto, IFormFile file)
        {
            var publication = _mapper.Map<Publication>(publicationDto);
            publication.Videos = new List<Video>();

            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    var video = new Video
                    {
                        FileName = file.FileName,
                        Title = "Título por defecto",
                        Description = "Descripción por defecto",
                        FileContent = memoryStream.ToArray()
                    };
                    publication.Videos.Add(video);
                }
            }

            if (publicationDto.Videos != null && publicationDto.Videos.Count > 0 &&
                publicationDto.VideoDetails != null && publicationDto.VideoDetails.Count == publicationDto.Videos.Count)
            {
                for (int i = 0; i < publicationDto.Videos.Count; i++)
                {
                    var videoFile = publicationDto.Videos[i];
                    var videoDetail = publicationDto.VideoDetails[i];

                    var video = new Video
                    {
                        FileName = videoFile.FileName,
                        Title = videoDetail.Title,
                        Description = videoDetail.Description,
                    };

                    using (var memoryStream = new MemoryStream())
                    {
                        await videoFile.CopyToAsync(memoryStream);
                        video.FileContent = memoryStream.ToArray();
                    }

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




        public async Task CreatePublication(PublicationPostDto publication)
        {
            

            var publications = new Publication()
            {
                IdType = publication.IdType,
                IdUser = publication.IdUser,
                Professor = publication.Professor,
                Price = publication.Price,
                Title = publication.Title,
                Description = publication.Description,
                DescriptionProgram = publication.DescriptionProgram,
                Duration = publication.Duration,
                DurationWeek = publication.DurationWeek,
                Category = publication.Category,
                KnowledgeLevel = publication.KnowledgeLevel,
                Favorite = publication.Favorite,
                Comprado = publication.Comprado
            };
            await _PublicationRepository.AddPublication(publications);
            
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
