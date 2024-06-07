using LlamitraApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LlamitraApi.Repository.IRepository
{
    public class VideoRepository(ProyectoIContext context) : IVideoRepository
    {
        private readonly ProyectoIContext _context = context;

        public async Task AddVideo(Video video)
        {
            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Video>> GetAllVideo()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<Video> GetVideoById(int id)
        {
            return await _context.Videos.FirstOrDefaultAsync(v => v.IdVideo == id);
        }

        public async Task UpdateVideo(Video video)
        {
            _context.Videos.Entry(video).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVideo(Video video)
        {
            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
        }

    }
}
