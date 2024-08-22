using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;

namespace LlamitraApi.Repository.IRepository
{
    public interface IPublicationRepository
    {
        Task AddPublication(Publication publication);
        Task<Publication> GetPublicationById(int id);
        Task<List<Publication>> GetAllPublication();
        Task UpdatePublication(Publication publication);
        Task DeletePublication(Publication publication);
    }
}
