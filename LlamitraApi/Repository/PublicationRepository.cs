using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LlamitraApi.Repository
{
    public class PublicationRepository(ProyectoIContext dbContext) : IPublicationRepository
    {
        private readonly ProyectoIContext _dbContext = dbContext;

        public async Task AddPublication(Publication publication)
        {
            var idType = await _dbContext.PublicationTypes.FindAsync(publication.IdType);
            publication.IdTypeNavigation = idType;
            await _dbContext.Publications.AddAsync(publication);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Publication>> GetAllPublication()
        {
            return await _dbContext.Publications.ToListAsync();

        }
        public async Task<Publication> GetPublicationById(int id)
        {
            return await _dbContext.Publications.FirstOrDefaultAsync(p => p.IdPublication == id);
        }
        public Task UpdatePublication(Publication publication)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePublication(Publication publication)
        {
            _dbContext.Publications.Remove(publication);
            await _dbContext.SaveChangesAsync();
        }

    }
}
