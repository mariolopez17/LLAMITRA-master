/*using LlamitraApi.Models;
using LlamitraApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LlamitraApi.Repository
{
    public class InLiveRepository : IInLiveRepository
    {
        private readonly ProyectoIContext _context;

        public InLiveRepository(ProyectoIContext context)
        {
            _context = context;
        }
        public async Task AddInLive(InLive inLive)
        {
            await _context.InLives.AddAsync(inLive);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<InLive>> GetAllInLives()
        {
            return await _context.InLives.ToListAsync();
        }

        public async Task<InLive> GetInLiveById(int id)
        {
            return await _context.InLives.FirstOrDefaultAsync(i => i.IdLive == id);
        }

        public Task UpdateInLive(InLive inLive)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteInLive(InLive inLive)
        {
            _context.InLives.Remove(inLive);
            await _context.SaveChangesAsync();
        }

    }
}*/
