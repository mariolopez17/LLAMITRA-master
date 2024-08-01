using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Services;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LlamitraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PublicationTypeController(IPublicationTypeServices TypeService) : ControllerBase 
    {
        public readonly IPublicationTypeServices _TypeService = TypeService;

        [HttpPost]
        public async Task<IActionResult> RegisterPublicationType(PublicationTypePostDto publicationTypeDto)
        {
            try
            {
                var existingUser = await _TypeService.CheckNamePublicationType(publicationTypeDto.Name);
                if (existingUser != null)
                {
                    return Conflict("Ya hay un usuario registrado con este mail, inicie sesion o pruebe otro mail.");
                }
                await _TypeService.CreatePublicationType(publicationTypeDto);
                return Ok("Usuario registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar el usuario: {ex.Message}, tu error no esta dentro de los errores validados");
            }
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var publicationTypeDto = await _TypeService.GetAll();
                return Ok(publicationTypeDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener todos los tipos de publicaciones: {ex.Message}");
            }
        }
    }
}
