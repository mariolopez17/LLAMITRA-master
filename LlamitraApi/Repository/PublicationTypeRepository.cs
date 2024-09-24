using LlamitraApi.Models;
using LlamitraApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LlamitraApi.Repository
{
    public class PublicationTypeRepository(ProyectoIContext dbContext) : IPublicationTypeRepository
    {
        private readonly ProyectoIContext _dbContext = dbContext;

        public async Task AddPublicationType(PublicationType PublicationType)
        {
            await _dbContext.PublicationTypes.AddAsync(PublicationType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PublicationType> CheckPublicationType(string categoryName)
        {
            return await _dbContext.PublicationTypes.FirstOrDefaultAsync(u => u.Name == categoryName);
        }
        public async Task<List<PublicationType>> GetAllPublicationType()
        {
            return await _dbContext.PublicationTypes.ToListAsync();
        }
    }
}
