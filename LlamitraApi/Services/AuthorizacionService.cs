using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LlamitraApi.Models;
using LlamitraApi.Models.Custom;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using LlamitraApi.Services.IServices;
using System.Linq.Expressions;
using LlamitraApi.Models.Dtos.UserDtos;

namespace LlamitraApi.Services
{
    public class AuthorizacionService : IAuthorizacionService
    {
        private readonly IConfiguration _configuration;
        private readonly ProyectoIContext _proyectoIContext;

        public AuthorizacionService(IConfiguration configuration, ProyectoIContext proyectoIContext)
        {
            _configuration = configuration;
            _proyectoIContext = proyectoIContext;
        }

        private string GenerarToken(string idUsuario)
        {
            var Key = _configuration.GetValue<string>("JwtSettings:Key");
            var KeyBytes = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, idUsuario));

            var credencialsTokens = new SigningCredentials(KeyBytes,SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credencialsTokens,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);
            return tokenCreado;
        }

        public async Task<AuthorizacionResponse> DevolverToken(LoginDto authorizacion)
        {
            var usuario_encontrado = _proyectoIContext.Users.FirstOrDefault(x =>
            x.Mail == authorizacion.Mail &&
            x.Password == authorizacion.Password 
            );

            if(usuario_encontrado == null)
            {
                return await Task.FromResult<AuthorizacionResponse>(null);
            }

            string tokenCreado = GenerarToken(usuario_encontrado.IdUser.ToString());

            return new AuthorizacionResponse() { Token = tokenCreado, Resultado= true, Msg= "Ok" };
        }
    }
}
