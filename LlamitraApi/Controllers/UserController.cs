﻿using LlamitraApi.Commons.Enum;
using LlamitraApi.Commons;
using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LlamitraApi.Controllers
{
    [ApiController]
    [Route("/api/user")]
    public class UserController(IUserServices usuarioService) : ControllerBase
    {
        public readonly IUserServices _userService = usuarioService;

        [HttpPost]

        public async Task<IActionResult> RegisterUser(UserPostDto userDto)
        {
            try
            {
                var existingUser = await _userService.CheckMailUser(userDto.Mail);
                if (existingUser != null)
                {
                    return Conflict("Ya hay un usuario registrado con este mail, inicie sesion o pruebe otro mail.");
                }
                await _userService.CreateUser(userDto);
                return Ok("Usuario registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar el usuario: {ex.Message}, tu error no esta dentro de los errores validados");
            }
        }
        [HttpGet("/api/user")]
        [Authorize(Policy = "profesor")]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetAll()
        {
            try
            {
                var publicationTypeDto = await _userService.GetAll();
                if (publicationTypeDto == null)
                {
                    return new ResponseObjectJsonDto()
                    {
                        Code = (int)CodeHttp.NOTFOUND,
                        Message = "No se encontro ningun tipo de publicacion",
                        Response = null
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
                return StatusCode(500, $"Error al obtener todos los tipos de publicaciones: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "profesor")]
        public async Task<ActionResult<ResponseObjectJsonDto>> GetUserById(int id)
        {
            try
            {
                var inLives = await _userService.GetByIdUser(id);
                return Ok(inLives);
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
                return StatusCode(500, $"Error al obtener todos los vivos: {ex.Message}");
            }
        }
    }
}
