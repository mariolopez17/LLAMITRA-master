using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;

namespace LlamitraApi.Services
{
    public class InLiveServices(IInLiveRepository courseRepository) : IInLiveServices
    {
        private readonly IInLiveRepository _inLiveRepository = courseRepository;

        public async Task Create(InLivePostDto inLive)
        {
            var InLive = new InLive()
            {
                //IdCategory = inLive.IdCategory,
                Professor = inLive.Professor,
                Price = inLive.Price,
                Title = inLive.Title,
                Description = inLive.Description,
                Url = inLive.Url,
            };
            await _inLiveRepository.AddInLive(InLive);
        }
        public async Task Delete(InLive inLive)
        {
            await _inLiveRepository.DeleteInLive(inLive);
        }

        public async Task<IEnumerable<InLive>> GetAll()
        {
            return await _inLiveRepository.GetAllInLives();
        }

        public async Task<InLive> GetById(int id)
        {
            return await _inLiveRepository.GetInLiveById(id);
        }

        public Task Update(InLive inLive)
        {
            throw new NotImplementedException();
        }
    }
}
