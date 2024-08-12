using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.JsonWebTokens;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models.Dtos.UserDtos;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using LlamitraApi.Services.IServices;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Repository;
using LlamitraApi.Services;
using Microsoft.AspNetCore.Authentication;
using LlamitraApi.Models;

namespace LlamitraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //TODO hacer este controlador un servicio// 
    public class AuthenticationController : ControllerBase
    {
        //public readonly string secretkey;

        //public AuthenticationController(IConfiguration config)
        //{
        //    secretkey = config.GetSection("settings").GetSection("secretKey").ToString();
        //}

        //[HttpPost]
        //[Route("Validar")]
        //public IActionResult Validar([FromBody] User request)
        //{
        //    if (request.IdRol == 1 || request.IdRol == 2)
        //    {
        //        var keyBytes = Encoding.ASCII.GetBytes(secretkey);
        //        var claims = new ClaimsIdentity();

        //        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Name));
        //        claims.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
        //        claims.AddClaim(new Claim(ClaimTypes.Role, "User"));
                

        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = claims,
        //            Expires = DateTime.UtcNow.AddMinutes(10),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256)

        //        };
        //        //Lectura del token
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

        //        string tokenCreado = tokenHandler.WriteToken(tokenConfig);


        //        return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });
        //    }
        //    else
        //    {
        //        return StatusCode(StatusCodes.Status401Unauthorized, new { respuesta = "El numero de Acceso ingresado no es de un admin" });
        //    }
        //}
    }

    //public class AuthenticationController(IAuthenticationService AuthenticationService) : ControllerBase
    //{
    //    private readonly IAuthenticationService _AuthenticationService = AuthenticationService;

    //    public AuthenticationController(IAuthenticationService AuthenticationService)
    //    {
    //        _AuthenticationService = AuthenticationService;
    //    }

    //    [HttpPost]

    //    public IActionResult Validar(UserPostDto request)
    //    {
    //        _AuthenticationService.Validar(request);
    //        return Ok();
    //    }
    //}
}
