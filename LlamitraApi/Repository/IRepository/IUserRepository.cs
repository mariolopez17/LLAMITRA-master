using LlamitraApi.Models;

namespace LlamitraApi.Repository.IRepository
{
    public interface IUserRepository
    {
        Task AddUser(User User);
        Task <User> CheckUser(string mail);

    }
}
