using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;

namespace LlamitraApi.Services
{
    public class UserServices(IUserRepository userRepository) : IUserServices
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task CreateUser(UserPostDto userPost)
        {
            var user = new User
            {
                Name = userPost.Name,
                Lastname = userPost.LastName,
                Mail = userPost.Mail,
                IdRol = userPost.IdRol,
                Password = userPost.Password
            };
            
            await _userRepository.AddUser(user);
        }

        public async Task<User> CheckMailUser(string email)
        {
            return await _userRepository.CheckUser(email);
        }
    }
}
