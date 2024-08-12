using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.UserDtos;
using System.Collections.Generic;

namespace LlamitraApi.Repository.IRepository
{
    public interface IUserRepository
    {
        Task AddUser(User User);
        Task<User> CheckUser(string mail);
        Task<List<User>> GetAllUser();

    }
}
