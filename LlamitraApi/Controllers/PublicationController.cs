using AutoMapper;
using LlamitraApi.Commons;
using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace LlamitraApi.Controllers
{
    [ApiController]
    [Route("/publication")]
    [Authorize]
    public class PublicationController(
        IPublicationServices PublicationServices, 
        IPublicationRepository publicationRepository, 
        IMapper mapper,
        IPublicationTypeRepository publicationTypeRepository) : ControllerBase
    {
        private readonly IPublicationServices _PublicationServices = PublicationServices;
        private readonly IPublicationRepository _publicationRepository = publicationRepository;
        private readonly IPublicationTypeRepository _publicationTypeRepository = publicationTypeRepository;
        private readonly IMapper _mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> RegisterPublication(PublicationPostDto publication)
        {
            try
            {
                await _PublicationServices.CreatePublication(publication);
                return Ok("Publicacion registrada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar la publicacion: {ex.Message}, tu error no esta dentro de los errores validados");
            }

        }

        [HttpGet]
        public async Task<ResponseObjectJsonDto> GetAll()
        {
        
            var publications = await _PublicationServices.GetAll();
            

            if (publications == null)
            {
                throw new ($"No se encontró un reclamo con el ID: ");
            }


            return new ResponseObjectJsonDto()
            {
                Code = (int)HttpStatusCode.OK,
                Message = "",
                Response = publications
            };
        }

        [HttpGet("{id}")]
        public async Task<ResponseObjectJsonDto> GetById(int id)
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
                    //Log.Error($"Claim not found, while handling GetClaimByIdQuery, with ID: {request.Id}");
                    //throw new NotFoundException($"No se encontró un reclamo con el ID: {request.Id}");
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
                return new ResponseObjectJsonDto()
                {
                    Code = 500,
                    Message = "Internal server error.",
                    Response = null
                };
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var publicationDelete = await _PublicationServices.GetById(id);
                if (publicationDelete == null)
                {
                    return NotFound($"No se obtuvo resultado con el id: {id}");
                }
                await _PublicationServices.DeletePublication(publicationDelete);
                return Ok("La publicacion se elimino con exito");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
