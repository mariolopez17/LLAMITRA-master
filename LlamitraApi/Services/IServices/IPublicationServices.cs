using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models;

namespace LlamitraApi.Services.IServices
{
    public interface IPublicationServices
    {
        Task CreatePublication(PublicationPostDto publication);
        Task SavePublicationAsync(PublicationPostDto publicationDto);
        Task<List<PublicacionGetDto>> GetAllPublicationsAsync();    
        Task<PublicacionGetDto> GetPublicationWithVideosById(int id);
        Task<List<PublicacionGetDto>> GetAll(); 
        Task<List<PublicacionGetDto>> GetRandomList(); 
        Task<Publication> GetById(int id); 
        Task UpdatePublication(Publication publication); 
        Task DeletePublication(Publication publication); 
    }
}
