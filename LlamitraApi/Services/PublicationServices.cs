using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models;
using LlamitraApi.Repository;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using AutoMapper;

namespace LlamitraApi.Services
{
    public class PublicationServices(IPublicationRepository PublicationRepository, IMapper mapper): IPublicationServices
    {
        private readonly IPublicationRepository _PublicationRepository = PublicationRepository;
        private readonly IMapper _mapper = mapper;

        public async Task CreatePublication(PublicationPostDto publication)
        {
            var ppublication = new Publication()
            {
                IdType = publication.IdType,
                IdUser = publication.IdUser,
                Professor = publication.Professor,
                Price = publication.Price,
                Title = publication.Title,
                Description = publication.Description,
                Url = publication.Url
            };
            await _PublicationRepository.AddPublication(ppublication);
        }

        public async Task<List<PublicationPostDto>> GetAll()
        {
            var publicationsDtos = new List<PublicationPostDto>();
            var publications = await _PublicationRepository.GetAllPublication();

            _mapper.Map(publications, publicationsDtos);

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
