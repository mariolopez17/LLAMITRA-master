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
        public async Task<List<Publication>> GetAllPublicationWithVideos()
        {
            return await _dbContext.Publications
                .Include(p => p.Videos)
                .ToListAsync();
        }
        public async Task<Publication> GetPublicationById(int id)
        {
            return await _dbContext.Publications
                .Include(p => p.Videos)
                .FirstOrDefaultAsync(p => p.IdPublication == id);
        }

        public async Task UpdatePublication(Publication publication)
        {
            var existingPublication = await _dbContext.Publications
                .Include(p => p.Videos)
                .FirstOrDefaultAsync(p => p.IdPublication == publication.IdPublication);

            if (existingPublication == null)
                throw new KeyNotFoundException("Publicación no encontrada.");

            
            _dbContext.Entry(existingPublication).CurrentValues.SetValues(publication);

            
            existingPublication.Videos.Clear();
            if (publication.Videos != null && publication.Videos.Any())
            {
                foreach (var video in publication.Videos)
                {
                    existingPublication.Videos.Add(video);
                }
            }

            await _dbContext.SaveChangesAsync();
        }



        public async Task DeletePublication(Publication publication)
        {
            _dbContext.Publications.Remove(publication);
            await _dbContext.SaveChangesAsync();
        }

    }
}
