using LlamitraApi.Models;
using LlamitraApi.Models.Custom;
using LlamitraApi.Models.Dtos.UserDtos;

namespace LlamitraApi.Services.IServices
{
    public interface IAuthorizacionService
    {
        Task<AuthorizacionResponse> DevolverToken(LoginDto authorizacion);

        Task<AuthorizacionResponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, int idUser);
    }
}
