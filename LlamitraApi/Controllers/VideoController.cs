using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Services;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LlamitraApi.Controllers
{
    [ApiController]
    [Route("Video")]
    public class VideoController(IVideoServices videoServices) : ControllerBase
    {
        private readonly IVideoServices _videoServices = videoServices;

        [HttpPost]
        [Route("RegisterVideo")]
        public async Task<IActionResult> RegisterVideo(VideoPostDto video)
        {
            try
            {
                await _videoServices.Create(video);
                return Ok("Video registrado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar video: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetAllRandom")]
        public async Task<IActionResult> GetAllRandom()
        {
            try
            {
                var inLives = await _videoServices.GetAll();
                var randomInLives = inLives.OrderBy(x => Guid.NewGuid()).ToList(); // Ordena de forma aleatoria

                return Ok(randomInLives);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener todos los vivos de forma aleatoria: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var presential = await _videoServices.GetAll();
                return Ok(presential);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener todos los videos: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var inLives = await _videoServices.GetById(id);
                return Ok(inLives);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el video: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeleteVideo")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var inLiveToDelete = await _videoServices.GetById(id);
                if (inLiveToDelete == null)
                {
                    return NotFound($"No se obtuvo resultado con el id: {id}");
                }

                await _videoServices.Delete(inLiveToDelete);
                return Ok("El Video se elimino con exito");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }   
}
