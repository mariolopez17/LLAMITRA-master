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
    [Route("/publication")]
    //[Authorize(Roles = "Admin")]

    public class PublicationController(
        IPublicationServices PublicationServices,
        IPublicationRepository publicationRepository,
        IMapper mapper
        ) : ControllerBase
    {
        
        private readonly IPublicationServices _PublicationServices = PublicationServices;
        private readonly IPublicationRepository _publicationRepository = publicationRepository;
        private readonly IMapper _mapper = mapper;

        [HttpPost("create")]
        public async Task<ActionResult> CreatePublication([FromForm] PublicationPostDto publication, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Debe proporcionar un archivo.");
            }

            await _PublicationServices.SavePublicationAsync(publication, file); 

            return StatusCode(201, "Publicación creada con éxito.");
        }

        
        [HttpPost("Presencial")]
        [Authorize]
        public async Task<ActionResult<ResponseObjectJsonDto>> RegisterPublication(PublicationPostDto Creationpublication)
        {
            try
            {
                await _PublicationServices.CreatePublication(Creationpublication);
                if (Creationpublication == null)
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)CodeHttp.NOTFOUND,
                        Message = "No se cargo de manera correcta la publicacion",
                        Response = null
                    };
                }
                else
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)CodeHttp.OK,
                        Message = "Publicacion guardada",
                        Response = Creationpublication
                    };
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar la publicacion: {ex.Message}, tu error no esta dentro de los errores validados");
            }

        }
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
                    //throw new($"No se encontró una publicacion.");
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
        [HttpGet("RandomList")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetById(int id)
        {
            try
            {
                var publication = await _publicationRepository.GetPublicationById(id);


                if (publication == null)
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = 404,
                        Message = "Reclamo no encontrado.",
                        Response = null
                    };
                }
                else
                {
                    var publicationDto = _mapper.Map<PublicationPostDto>(publication);

                    return new ResponseObjectJsonDto()
                    {
                        Code = 200,
                        Message = "Reclamo activo.",
                        Response = publicationDto
                    };
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar la publicacion: {ex.Message}, tu error no esta dentro de los errores validados");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]

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
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    } 
}
