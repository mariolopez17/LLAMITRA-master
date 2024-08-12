using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;

namespace LlamitraApi.Repository.IRepository
{
    public interface IPublicationTypeRepository
    {
        Task AddPublicationType(PublicationType PublicationType);
        Task<PublicationType> CheckPublicationType(string name);
        Task<List<PublicationType>> GetAllPublicationType();
    }
}
