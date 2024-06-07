using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;

namespace LlamitraApi.Services.IServices
{
    public interface IPresentialServices
    {
        Task Create(PresentialPostDto presential);
        Task<IEnumerable<Presential>> GetAll();
        Task<Presential> GetById(int id);
        Task Update(Presential presential);
        Task Delete(Presential presential);
    }
}
