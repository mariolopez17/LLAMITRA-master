/*using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Services;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LlamitraApi.Controllers
{
    [ApiController]
    [Route("/video")]
    public class VideoController(IVideoServices videoServices) : ControllerBase
    {
        private readonly IVideoServices _videoServices = videoServices;

        [HttpPost]
        public async Task<IActionResult> RegisterVideo(VideoPostDto video)
        {
            try
            {
                await _videoServices.Create(video);
                return Ok("Video registrado exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar video: {ex.Message}, tu error no esta dentro de los errores validados");
            }
        }

        [HttpGet("/videos_aleatorio")]
        public async Task<IActionResult> GetAllRandom()
        {
            try
            {
                var inLives = await _videoServices.GetAll();
                var randomInLives = inLives.OrderBy(x => Guid.NewGuid()).ToList(); 

                return Ok(randomInLives);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener todos los vivos de forma aleatoria: {ex.Message}");
            }
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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
}*/
