using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models;

namespace LlamitraApi.Services.IServices
{
    public interface IPublicationServices
    {
        Task CreatePublication(PublicationPostDto publication);
        Task<List<PublicationPostDto>> GetAll();
        Task<Publication> GetById(int id);
        Task UpdatePublication(Publication publication);
        Task DeletePublication(Publication publication);
    }
}
