using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models;

namespace LlamitraApi.Services.IServices
{
    public interface IPublicationServices
    {
        Task CreatePublication(PublicationPostDto publication);
        Task<List<PublicacionGetDto>> GetAll();
        Task<Publication> GetById(int id);
        //Task<List<PublicationPostDto>> GetById(int id);
        Task UpdatePublication(Publication publication);
        Task DeletePublication(Publication publication);
    }
}
