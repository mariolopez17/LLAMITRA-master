
using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Services;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LlamitraApi.Controllers
{
    [ApiController]
    [Route("InLive")]
    public class InLiveController(IInLiveServices inLiveServices) : ControllerBase
    {
        private readonly IInLiveServices _inLiveServices = inLiveServices;

        
        [HttpPost]
        [Route("RegisterInLive")]
        public async Task<IActionResult> RegisterInLive(InLivePostDto inlive)
        {
            try
            {
                await _inLiveServices.Create(inlive);
                return Ok("Vivo registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar vivo: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var inLives = await _inLiveServices.GetAll();
                return Ok(inLives);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener todos los vivos: {ex.Message}");
            }
        }
        
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var inLives = await _inLiveServices.GetById(id);
                return Ok(inLives);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener todos los vivos: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeleteInLive")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var inLiveDelete = await _inLiveServices.GetById(id);
                if (inLiveDelete == null)
                {
                    return NotFound($"No se obtuvo resultado con el id: {id}");
                }

                await _inLiveServices.Delete(inLiveDelete);
                return Ok("El vivo se elimino con exito");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
