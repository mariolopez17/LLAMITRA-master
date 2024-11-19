using AutoMapper;
using LlamitraApi.Helpers.Metodos;
using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Repository;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;
using System.Security.Cryptography;
using System.Text;

namespace LlamitraApi.Services
{
    public class UserServices(IUserRepository userRepository, IMapper mapper, IEmailServices emailService) : IUserServices
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IEmailServices _emailService= emailService;
        public async Task CreateUser(UserPostDto userPost)
        {
            var user = new User
            {
                Name = userPost.Name,
                Lastname = userPost.LastName,
                Mail = userPost.Mail,
                IdRol = userPost.IdRol,
                Password = Encrypt.GetSHA256(userPost.Password)
            };
            await _userRepository.AddUser(user);

            string htmlContent = _emailService.GetHtmlContent("EmailRegistro.html");


            var emailRequest = new EmailDTO
            {
            Para = userPost.Mail,
            Asunto = "Confirmación de Registro",
            Contenido = htmlContent
            };

            _emailService.SendEmail(emailRequest);
        }
        public async Task<User> CheckMailUser(string email)
        {
            return await _userRepository.CheckUser(email);
        }
        public async Task<List<UserPostDto>> GetAll()
        {
            var usersDto = new List<UserPostDto>();
            var users = await _userRepository.GetAllUser();

            _mapper.Map(users, usersDto);

            return usersDto;
        }

        public async Task<User> GetByIdUser(int id)
        {
            return await _userRepository.GetUserById(id);
        }
    }
}
