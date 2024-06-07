using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;

namespace LlamitraApi.Services
{
    public class PresentialServices(IPresentialRepository presentialRepository) : IPresentialServices
    {
        private readonly IPresentialRepository _presentialRepository = presentialRepository;

        public async Task Create(PresentialPostDto presential)
        {
            var Presential = new Presential()
            {
                //IdCategory = presential.IdCategory,
                Professor = presential.Professor,
                Price = presential.Price,
                Title = presential.Title,
                Description = presential.Description
            };
            await _presentialRepository.AddPresential(Presential);
        }

        public async Task<IEnumerable<Presential>> GetAll()
        {
            return await _presentialRepository.GetAllPresential();
        }

        public async Task<Presential> GetById(int id)
        {
            return await _presentialRepository.GetPresentialById(id);
        }

        public Task Update(Presential presential)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Presential presential)
        {
            await _presentialRepository.DeletePresential(presential);
        }

    }
}
