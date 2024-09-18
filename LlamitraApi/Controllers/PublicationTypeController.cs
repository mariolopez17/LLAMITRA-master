using LlamitraApi.Commons;
using LlamitraApi.Commons.Enum;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Services;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LlamitraApi.Controllers
{
    [Route("/api/publication-type")]
    [ApiController]
    //[Authorize]
    public class PublicationTypeController(IPublicationTypeServices TypeService) : ControllerBase 
    {
        public readonly IPublicationTypeServices _TypeService = TypeService;
        
        [HttpPost]
        [Authorize(Policy = "profesor")]
        public async Task<ActionResult<ResponseObjectJsonDto>> RegisterPublicationType(PublicationTypePostDto publicationTypeDto)
        {
            try
            {
                var existingUser = await _TypeService.CheckNamePublicationType(publicationTypeDto.Name);
                await _TypeService.CreatePublicationType(publicationTypeDto);
                if (existingUser != null)
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code= (int)CodeHttp.CONFLICT,
                        Message= "Ya hay un tipo de publicacion con este nombre",
                        Response = null
                    };
                }else {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)CodeHttp.OK,
                        Message = "tipo de publicacion registrada exitosamente.",
                        Response = publicationTypeDto
                    };
                }            
            }
            catch (UnauthorizedAccessException)
            {
                return new ResponseObjectJsonDto()
                {
                    Code = (int)CodeHttp.FORBIDDEN,
                    Message = "No tienes acceso porque no eres profesor.",
                    Response = null
                };
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar el usuario: {ex.Message}, tu error no esta dentro de los errores validados");
            }
        }
        [HttpGet()]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetAll()
        {
            try
            {
                var publicationTypeDto = await _TypeService.GetAll();
                if (publicationTypeDto == null)
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)CodeHttp.NOTFOUND,
                        Message= "No se encontro ningun tipo de publicacion",
                        Response= null
                    };
                }
                else
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)CodeHttp.OK,
                        Message = "tipo de publicacion encontrada con exito.",
                        Response = publicationTypeDto
                    };
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener todos los tipos de publicaciones: {ex.Message}");
            }
        }
    }
}
