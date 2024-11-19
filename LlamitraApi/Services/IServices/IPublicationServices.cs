using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models;

namespace LlamitraApi.Services.IServices
{
    public interface IPublicationServices
    {
        Task CreatePublication(PublicationPostDto publication);
        Task<List<PublicacionGetDto>> GetAllPublicationsAsync();    
        Task<PublicacionGetDto> GetPublicationWithVideosById(int id);
        Task<List<PublicacionGetDto>> GetRandomList(); 
        Task<Publication> GetById(int id);
        Task UpdatePublication(int id, PublicationPostDto publicationDto);

        Task DeletePublication(Publication publication); 
    }
}
