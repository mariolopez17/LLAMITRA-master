using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LlamitraApi.Services;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Services.IServices;
using Microsoft.AspNetCore.Authorization;

namespace LlamitraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmailController : ControllerBase
    {
       private readonly IEmailServices _emailServices;

       public EmailController(IEmailServices emailServices)
       {
          _emailServices = emailServices;
       }

        [HttpPost]

        public IActionResult SendEmail(EmailDTO request)
        {
            _emailServices.SendEmail(request);
            return Ok();
        }
    }
}
