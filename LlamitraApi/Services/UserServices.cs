using AutoMapper;
using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.CourseDtos;
using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Repository;
using LlamitraApi.Repository.IRepository;
using LlamitraApi.Services.IServices;

namespace LlamitraApi.Services
{
    public class UserServices(IUserRepository userRepository, IMapper mapper) : IUserServices
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
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
        public async Task<List<UserPostDto>> GetAll()
        {
            var usersDto = new List<UserPostDto>();
            var users = await _userRepository.GetAllUser();

            _mapper.Map(users, usersDto);

            return usersDto;
            //return await _userRepository.GetAllUser();
        }

        public async Task<User> GetByIdUser(int id)
        {
            return await _userRepository.GetUserById(id);
        }
    }
}
