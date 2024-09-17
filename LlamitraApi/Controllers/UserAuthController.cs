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
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly IAuthorizacionService _authorizacionService;
        public UserAuthController(IAuthorizacionService authorizacionService)
        {
            _authorizacionService = authorizacionService;
        }
        
        [HttpPost]
        [Route("/api/login")]
        public async Task<IActionResult> authenticate([FromBody] LoginDto authorizacion)
        {
            var result_authorizacion = await _authorizacionService.DevolverToken(authorizacion);
            if(result_authorizacion == null)
            {
                return Unauthorized();
            }
            
            return Ok(result_authorizacion);
            
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
    }
}
