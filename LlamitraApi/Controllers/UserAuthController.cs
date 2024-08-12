using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LlamitraApi.Models.Custom;
using LlamitraApi.Services;
using LlamitraApi.Services.IServices;
using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Models;

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
        [Route("Autenticar")]

        public async Task<IActionResult> authenticate([FromBody] LoginDto authorizacion)
        {
            var result_authorizacion = await _authorizacionService.DevolverToken(authorizacion);
            if(result_authorizacion == null)
            {
                return Unauthorized();
            }else
            {
                return Ok(result_authorizacion);
            }
        }
    }
}
