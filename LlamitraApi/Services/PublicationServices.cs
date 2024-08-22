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
            
            if (file != null)
            {
                
                publication.FileName = file.FileName;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream); 
                    publication.FileContent = memoryStream.ToArray();
                }

                _dbContext.Publications.Add(publication);
                await _dbContext.SaveChangesAsync();
            }
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
                FileContent = publication.FileContent
            };
            await _PublicationRepository.AddPublication(publications);
            
        }
        public async Task<List<PublicacionGetDto>> GetAll()
        {
            var publicationsDtos = new List<PublicacionGetDto>();
            var publications = await _PublicationRepository.GetAllPublication();

            _mapper.Map(publications, publicationsDtos);

            return publicationsDtos;
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
