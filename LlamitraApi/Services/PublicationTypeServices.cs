using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Models;
using LlamitraApi.Repository;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using LlamitraApi.Models.Dtos.CourseDtos;
using AutoMapper;

namespace LlamitraApi.Services
{
    public class PublicationTypeServices(IPublicationTypeRepository PublicationTypeRepository, IMapper mapper) : IPublicationTypeServices
    {
        private readonly IPublicationTypeRepository _PublicationTypeRepository = PublicationTypeRepository;
        private readonly IMapper _mapper = mapper;
        public async Task CreatePublicationType(PublicationTypePostDto publicationTypePost)
        {
            var publicationType = new PublicationType
            {
                Name = publicationTypePost.Name
            };

            await _PublicationTypeRepository.AddPublicationType(publicationType);
        }
        public async Task<PublicationType> CheckNamePublicationType(string categoryName)
        {
            return await _PublicationTypeRepository.CheckPublicationType(categoryName);
        }
        public async Task<List<PublicationTypePostDto>> GetAll()
        {
            var publicationsTypeDtos = new List<PublicationTypePostDto>();
            var publicationstype = await _PublicationTypeRepository.GetAllPublicationType();

            _mapper.Map(publicationstype, publicationsTypeDtos);

            return publicationsTypeDtos;
            //return await _PublicationTypeRepository.GetAllPublicationType();
        }
        /*public async Task<List<PublicationTypePostDto>> GetAll()
        {
            var publicationsTypeDtos = new List<PublicationTypePostDto>();
            var publicationstype = await _PublicationTypeRepository.GetAllPublicationType();

            _mapper.Map(publicationstype, publicationsTypeDtos);

            return publicationsTypeDtos;
            //return await _PublicationTypeRepository.GetAllPublicationType();
        }*/
    }
}
