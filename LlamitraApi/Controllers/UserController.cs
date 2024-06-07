using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LlamitraApi.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UserController(IUserServices usuarioService) : ControllerBase
    {
        public readonly IUserServices _userService = usuarioService;

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser(UserPostDto userDto)
        {
            try
            {
                //Verificar si el usuario ya existe
                var existingUser = await _userService.CheckMailUser(userDto.Mail);
                if (existingUser != null)
                {
                    return Conflict("Ya hay un usuario registrado con este mail, inicie sesion o pruebe otro mail.");
                }

                //Pasar el Dto al service
                await _userService.CreateUser(userDto);

                return Ok("Usuario registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar usuario: {ex.Message}");
            }
        }
    }
}
