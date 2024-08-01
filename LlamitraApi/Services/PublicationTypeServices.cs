using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Models;
using LlamitraApi.Repository;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using LlamitraApi.Models.Dtos.CourseDtos;

namespace LlamitraApi.Services
{
    public class PublicationTypeServices(IPublicationTypeRepository PublicationTypeRepository) : IPublicationTypeServices
    {
        private readonly IPublicationTypeRepository _PublicationTypeRepository = PublicationTypeRepository;

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
        public async Task<IEnumerable<PublicationType>> GetAll()
        {
            return await _PublicationTypeRepository.GetAllPublicationType();
        }
    }
}
