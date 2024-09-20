using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LlamitraApi.Models.Custom;
using LlamitraApi.Services;
using LlamitraApi.Services.IServices;
using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;

namespace LlamitraApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IAuthorizacionService _authorizacionService;
        public UserAuthController(IAuthorizacionService authorizacionService)
        {
            _authorizacionService = authorizacionService;
        }
        [HttpPost]
        [Route("/api/get-refresh-token")]
        public async Task<IActionResult> ObtenerRefreshToken([FromBody] RefreshTokenRequest request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var TokenExpiredsupposedly = tokenHandler.ReadJwtToken(request.TokenExpirado);

            if (TokenExpiredsupposedly.ValidTo > DateTime.UtcNow)
                return BadRequest(new AuthorizacionResponse { Resultado = false, Msg = "El token no a expirado" });

            string idUser = TokenExpiredsupposedly.Claims.First(x=>
            x.Type == JwtRegisteredClaimNames.NameId).Value.ToString();

            var autorizacionResponse = await _authorizacionService.DevolverRefreshToken(request, int.Parse(idUser));

            if (autorizacionResponse.Resultado)
            {
                return Ok(autorizacionResponse);
            }
            else
            {
                return BadRequest(autorizacionResponse);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest("No has cargado tus datos");
            }

            var response = await _authorizacionService.DevolverTokenConDatosUsuario(loginDto);

            if (response == null)
            {
                return Unauthorized("tu email o tu contraseña no son validads");
            }

            return Ok(response);
        }
    }
    
}
