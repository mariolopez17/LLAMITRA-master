using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models.Dtos.UserDtos;

namespace LlamitraApi.Services.IServices
{
    public interface IPublicationTypeServices
    {
        Task CreatePublicationType(PublicationTypePostDto publicationTypeDto);
        Task<PublicationType> CheckNamePublicationType(string name);
        Task<IEnumerable<PublicationType>> GetAll();
    }
}
