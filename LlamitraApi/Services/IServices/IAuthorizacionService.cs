using LlamitraApi.Dtos;
using LlamitraApi.Models;
using LlamitraApi.Models.Custom;
using LlamitraApi.Models.Dtos.UserDtos;

namespace LlamitraApi.Services.IServices
{
    public interface IAuthorizacionService
    {
        Task<TokenAndUserDataResponse> DevolverTokenConDatosUsuario(LoginDto authorizacion);
        Task<AuthorizacionResponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, int idUser);
    }
}
