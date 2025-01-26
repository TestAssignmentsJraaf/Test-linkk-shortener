using DAL.Entities;
using DAL.Repositories.Base;

namespace DAL.Repositories.Interfaces;

public interface IUserRepository : IRepo<User, int>
{
    Task<bool> UserExists(string username);
    Task<User> GetByUsername(string username);
}
