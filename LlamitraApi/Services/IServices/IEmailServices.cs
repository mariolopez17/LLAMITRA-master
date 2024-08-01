using LlamitraApi.Models.Dtos.CourseDtos;
namespace LlamitraApi.Services.IServices
{
    public interface IEmailServices
    {
       void SendEmail(EmailDTO request);
    }
}
