using LlamitraApi.Models.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LlamitraApi.Services
{
    /*public class AuthenticationService
    {
        public readonly string secretkey;

        public AuthenticationService(IConfiguration config)
        {
            secretkey = config.GetSection("settings").GetSection("secretKey").ToString();
        }

        //[HttpPost]
        //[Route("Validar")]
        public void Validar([FromBody] UserPostDto request)
        {
            if (request.IdRol == 1 || request.IdRol == 2)
            {
                var keyBytes = Encoding.ASCII.GetBytes(secretkey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Name));
                claims.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                claims.AddClaim(new Claim(ClaimTypes.Role, "User"));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256)

                };
                //Lectura del token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                
                //return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });
            }
            else
            {
                //return StatusCode(StatusCodes.Status401Unauthorized, new { respuesta = "El numero de Acceso ingresado no es de un admin" });
            }
        }
    }*/
}
