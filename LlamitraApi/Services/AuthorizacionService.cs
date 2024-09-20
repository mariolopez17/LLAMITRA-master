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
using LlamitraApi.Helpers.Metodos;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using LlamitraApi.Dtos;
using LlamitraApi.Commons.Enum;

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

        private string GenerarToken(string idUsuario, Claim[] claimsToAdd)
        {
            var Key = _configuration.GetValue<string>("JwtSettings:Key");
            var KeyBytes = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

            var claims = new ClaimsIdentity();
            claims.AddClaims(claimsToAdd);
            

            var credencialsTokens = new SigningCredentials(KeyBytes,SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = credencialsTokens,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);
            return tokenCreado;
        }
        private string GenerarRefreshToken()
        {
            var byteArray = new byte[64];
            var refreshToken = "";

            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(byteArray);
                refreshToken= Convert.ToBase64String(byteArray);
            }
            return refreshToken;
        }

        private async Task<AuthorizacionResponse> GuardarHistorialRefreshToken(
            int idUsuario,
            string token,
            string refreshToken
            )
        {
            var historialRefreshToken = new HistorialRefreshToken
            {
                IdUser = idUsuario,
                Token = token,
                RefreshToken = refreshToken,
                CreatedAt = DateTime.UtcNow,
                ExpiratedAt = DateTime.UtcNow.AddDays(1)
            };
            await _proyectoIContext.HistorialRefreshTokens.AddAsync(historialRefreshToken);
            await _proyectoIContext.SaveChangesAsync();

            return new AuthorizacionResponse { Token =token,RefreshToken=refreshToken,Resultado=true,Msg="OK" };
        }
        public async Task<TokenAndUserDataResponse> DevolverTokenConDatosUsuario(LoginDto authorizacion)
        {
            var usuario_encontrado = _proyectoIContext.Users.FirstOrDefault(x =>
                x.Mail == authorizacion.Mail &&
                x.Password == Encrypt.GetSHA256(authorizacion.Password)
            );

            if (usuario_encontrado == null)
            {
                return null; 
            }

            var rol_encontrado = _proyectoIContext.Roles.FirstOrDefault(x => x.IdRol == usuario_encontrado.IdRol);
            if (rol_encontrado == null) return null; 

            var claims = new[]
            {
            new Claim(ClaimTypes.Role, rol_encontrado.Name),
            new Claim(ClaimTypes.NameIdentifier, usuario_encontrado.IdUser.ToString()),
            };

            string tokenCreado = GenerarToken(usuario_encontrado.IdUser.ToString(), claims);
            string refreshTokenCreated = GenerarRefreshToken();

           
            await GuardarHistorialRefreshToken(usuario_encontrado.IdUser, tokenCreado, refreshTokenCreated);

            var userData = new UserDataDto
            {
                Id = usuario_encontrado.IdUser,
                Name = usuario_encontrado.Name,
                Email = usuario_encontrado.Mail,
                Role = rol_encontrado.Name,
            };

            return new TokenAndUserDataResponse
            {
                TokenResponse = new AuthorizacionResponse
                {
                    Token = tokenCreado,
                    RefreshToken = refreshTokenCreated,
                    Resultado = true,
                    Msg = "Tu token tiene una duracion de una hora"
                },
                UserData = userData
            };
        }
        public async Task<AuthorizacionResponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, int idUser)
        {
            var refreshTokenEncontrado = _proyectoIContext.HistorialRefreshTokens.FirstOrDefault(x =>
            x.Token == refreshTokenRequest.TokenExpirado &&
            x.Token == refreshTokenRequest.RefreshToken &&
            x.IdUser == idUser);

            if (refreshTokenEncontrado == null)
            {
                return new AuthorizacionResponse { Resultado = false, Msg = "No existe un RefreshToken" };
            }

            var claims = new[] 
            {
                   new Claim(ClaimTypes.NameIdentifier, idUser.ToString()),
            };

            var refreshTokenCreated = GenerarRefreshToken();
            var tokenCreated = GenerarToken(idUser.ToString(), claims);

            return await GuardarHistorialRefreshToken(idUser, tokenCreated, refreshTokenCreated);
        }
        private ClaimsPrincipal ValidarToken(string token)
        {
            var key = _configuration.GetValue<string>("JwtSettings:Key");
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out _);
                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
