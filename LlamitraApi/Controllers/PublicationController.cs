using AutoMapper;
using LlamitraApi.Commons;
using LlamitraApi.Commons.Enum;
using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Repository;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Net;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace LlamitraApi.Controllers
{
    [ApiController]
    [Route("/api/publication")]

    public class PublicationController(
        IPublicationServices PublicationServices,
        IPublicationRepository publicationRepository,
        IMapper mapper
        ) : ControllerBase
    {
        
        private readonly IPublicationServices _PublicationServices = PublicationServices;
        private readonly IPublicationRepository _publicationRepository = publicationRepository;
        private readonly IMapper _mapper = mapper;


        [HttpPost]
        [Authorize(Policy = "profesor")]
        public async Task<ActionResult<ResponseObjectJsonDto>> CreatePublication([FromForm] PublicationPostDto publicationDto)
        {
            try
            {
                await _PublicationServices.SavePublicationAsync(publicationDto);
                return StatusCode(201, new ResponseObjectJsonDto
                {
                    Code = (int)CodeHttp.OK,
                    Message = "Publicación creada con éxito.",
                    Response = publicationDto
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new ResponseObjectJsonDto
                {
                    Code = (int)CodeHttp.FORBIDDEN,
                    Message = "No tienes acceso porque no eres profesor.",
                    Response = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectJsonDto
                {
                    Code = (int)CodeHttp.INTERNALSERVER,
                    Message = $"Error al registrar la publicación: {ex.Message}",
                    Response = null
                });
            }
        }



        [HttpPost("presencial")]
        [Authorize(Policy = "profesor")]
        public async Task<ActionResult<ResponseObjectJsonDto>> RegisterPublication([FromBody] PublicationPostDto creationPublication)
        {
            try
            {
                if (creationPublication == null)
                {
                    return BadRequest(new ResponseObjectJsonDto
                    {
                        Code = (int)CodeHttp.BADREQUEST,
                        Message = "La publicación no se ha cargado correctamente.",
                        Response = null
                    });
                }

                await _PublicationServices.CreatePublication(creationPublication);
                return Ok(new ResponseObjectJsonDto
                {
                    Code = (int)CodeHttp.OK,
                    Message = "Publicación guardada.",
                    Response = creationPublication
                });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new ResponseObjectJsonDto
                {
                    Code = (int)CodeHttp.FORBIDDEN,
                    Message = "No tienes acceso porque no eres profesor.",
                    Response = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseObjectJsonDto
                {
                    Code = (int)CodeHttp.INTERNALSERVER,
                    Message = $"Error al registrar la publicación: {ex.Message}, error no validado.",
                    Response = null
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PublicacionGetDto>> GetPublicationWithVideos(int id)
        {
            try
            {
                var publicationDto = await _PublicationServices.GetPublicationWithVideosById(id);
                return Ok(publicationDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Publicación no encontrada.");
            }
        }


        //[HttpGet("GetAllPublications")]
        //public async Task<ActionResult<ResponseObjectJsonDto>> GetAllPublications()
        //{
        //    try
        //    {
        //        var publications = await _PublicationServices.GetAllPublicationsAsync();
        //        return Ok(new ResponseObjectJsonDto
        //        {
        //            Code = (int)CodeHttp.OK,
        //            Message = "Lista de publicaciones obtenida con éxito.",
        //            Response = publications
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new ResponseObjectJsonDto
        //        {
        //            Code = (int)CodeHttp.INTERNALSERVER,
        //            Message = "Error al obtener las publicaciones.",
        //            Response = ex.Message
        //        });
        //    }
        //}

        [HttpGet]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetAll()
        {
            try
            {
                var publications = await _PublicationServices.GetAll();

                if (publications == null)
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)CodeHttp.NOTFOUND,
                        Message = "No se encontró una publicacion.",
                    };
                }

                else
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)HttpStatusCode.OK,
                        Message = "Se obtuvieron todas las publicaciones",
                        Response = publications
                    };
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar la publicacion: {ex.Message}, tu error no esta dentro de los errores validados");
            }
        }
        [HttpGet("random-list")]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetRandomList()
        {
            try
            {
                var publications = await _PublicationServices.GetRandomList();

                if (publications == null)
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)CodeHttp.NOTFOUND,
                        Message = "No se encontró una publicacion.",
                        Response = null
                    };
                }

                else
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)HttpStatusCode.OK,
                        Message = "Se obtuvieron todas las publicaciones",
                        Response = publications
                    };
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar la publicacion: {ex.Message}, tu error no esta dentro de los errores validados");
            }
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<ResponseObjectJsonDto>> GetById(int id)
        //{
        //    try
        //    {
        //        var publication = await _publicationRepository.GetPublicationById(id);


        //        if (publication == null)
        //        {
        //            return new ResponseObjectJsonDto()
        //            {
        //                Code = 404,
        //                Message = "Reclamo no encontrado.",
        //                Response = null
        //            };
        //        }
        //        else
        //        {
        //            var publicationDto = _mapper.Map<PublicationPostDto>(publication);

        //            return new ResponseObjectJsonDto()
        //            {
        //                Code = 200,
        //                Message = "Reclamo activo.",
        //                Response = publicationDto
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Error al registrar la publicacion: {ex.Message}, tu error no esta dentro de los errores validados");
        //    }
        //}

        [HttpDelete("{id}")]
        [Authorize(Policy = "profesor")]

        public async Task<ActionResult<ResponseObjectJsonDto>> Delete([FromRoute] int id)
        {
            try
            {
                var publicationDelete = await _PublicationServices.GetById(id);
                await _PublicationServices.DeletePublication(publicationDelete);
                if (publicationDelete == null)
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)CodeHttp.NOTFOUND,
                        Message = "no se encontro esa publicacion",
                        Response = null
                    };
                }
                else
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)CodeHttp.OK,
                        Message = "La publicacion se elimino con exito.",
                        Response = publicationDelete
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
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    } 
}
