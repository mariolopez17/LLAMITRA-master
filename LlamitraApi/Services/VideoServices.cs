/*using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace LlamitraApi.Services
{
    public class VideoServices(IVideoRepository videoRepository) : IVideoServices
    {
        private readonly IVideoRepository _videoRepository = videoRepository;

        public async Task Create(VideoPostDto video)
        {
            var Video = new Video()
            {
                Professor = video.Professor,
                Price = video.Price,
                Title = video.Title,
                Description = video.Description,
                Url = video.Url,
            };
            await _videoRepository.AddVideo(Video);
        }

        public async Task<IEnumerable<Video>> GetAll()
        {
            return await _videoRepository.GetAllVideo();
        }

        public async Task<Video> GetById(int id)
        {
            return await _videoRepository.GetVideoById(id);
        }

        public async Task Update(VideoPostDto video)
        {
            var VideoUpdate = new Video()
            {
                Professor = video.Professor,
                Price = video.Price,
                Title = video.Title,
                Description = video.Description,
                Url = video.Url,
            };
            await _videoRepository.UpdateVideo(VideoUpdate); 
        }

        public async Task Delete(Video video)
        {
            await _videoRepository.DeleteVideo(video);
        }
    }
}
*/