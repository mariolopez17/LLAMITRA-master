using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Services;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LlamitraApi.Controllers
{
    [ApiController]
    [Route("Course")]
    public class PresentialController(IPresentialServices presentialServices) : ControllerBase
    {
        private readonly IPresentialServices _presentialServices = presentialServices;

        [HttpPost]
        [Route("RegisterPresential")]
        public async Task<IActionResult> RegisterPresential(PresentialPostDto presential)
        {
            try
            {
                await _presentialServices.Create(presential);
                return Ok("Presencial registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar presencial: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var presential= await _presentialServices.GetAll();
                return Ok(presential);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener todos los presenciales: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var inLives = await _presentialServices.GetById(id);
                return Ok(inLives);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener el presencial: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("DeletePresential")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var presentialDelete = await _presentialServices.GetById(id);
                if (presentialDelete == null)
                {
                    return NotFound($"No se obtuvo resultado con el id: {id}");
                }

                await _presentialServices.Delete(presentialDelete);
                return Ok("Presencial se elimino con exito");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
