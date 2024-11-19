using LlamitraApi.Models.Dtos.CourseDtos;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using LlamitraApi.Services.IServices;
namespace LlamitraApi.Services
{

    public class EmailServices : IEmailServices
    {
        private readonly IConfiguration _config;

        public EmailServices(IConfiguration config)
        {
            _config = config;
        }

        public string GetHtmlContent(string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "helpers/emailRequest", fileName);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"El archivo HTML '{fileName}' no fue encontrado en '{path}'.");
            }

            return File.ReadAllText(path);
        }

        public void SendEmail(EmailDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserName").Value));
            email.To.Add(MailboxAddress.Parse(request.Para));
            email.Subject = request.Asunto;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Contenido,
            };
            using var smtp = new SmtpClient();
            smtp.Connect(
                _config.GetSection("Email:Host").Value,
                Convert.ToInt32(_config.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
                );
            smtp.Authenticate(_config.GetSection("Email:UserName").Value, _config.GetSection("Email:PassWord").Value);

            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
        
}
