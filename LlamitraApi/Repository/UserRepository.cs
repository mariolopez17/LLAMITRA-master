using AutoMapper;
using LlamitraApi.Models;
using LlamitraApi.Models.Dtos.UserDtos;
using LlamitraApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LlamitraApi.Repository
{
    //Aca como implementamos la interfaz, debemos tener los metodos declarados
    public class UserRepository(ProyectoIContext dbContext) : IUserRepository
    {
        private readonly ProyectoIContext _dbContext = dbContext;

        public async Task AddUser(User User)
        {
            await _dbContext.Users.AddAsync(User);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> CheckUser(string email)
        {
            // Buscar un usuario en función del correo electrónico
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Mail == email);
        }
    }
}
