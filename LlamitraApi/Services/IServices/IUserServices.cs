﻿using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.UserDtos;

namespace LlamitraApi.Services.IServices
{
    public interface IUserServices
    {
        Task CreateUser(UserPostDto userPost);
        Task<User> CheckMailUser(string mail);
        Task<List<UserPostDto>> GetAll();
        Task<User> GetByIdUser(int id);
    }
}
