using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models;

namespace LlamitraApi.Services.IServices
{
    public interface IPublicationServices
    {
        Task CreatePublication(PublicationPostDto publication);
        Task<List<PublicacionGetDto>> GetAll();

        Task<List<PublicacionGetDto>> GetRandomList();
        Task<Publication> GetById(int id);
        Task UpdatePublication(Publication publication);
        Task DeletePublication(Publication publication);
    }
}
