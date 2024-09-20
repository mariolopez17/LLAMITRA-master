using LlamitraApi.Dtos;

namespace LlamitraApi.Models.Custom
{
    public class TokenAndUserDataResponse
    {
        public AuthorizacionResponse TokenResponse { get; set; }
        public UserDataDto UserData { get; set; }
    }
}
