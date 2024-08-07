﻿using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LlamitraApi.Controllers
{
    [ApiController]
    [Route("/usuario")]
    [Authorize]
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
    }
}
