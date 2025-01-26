using BLL.DTO;
using DAL.Entities;

namespace BLL.Services.Interfaces;

public interface IUserService
{
    Task<bool> UserExists(string username);
    Task<UserDTO> Register(CreateUserDTO user);
    Task<UserDTO> Login(LoginUserDTO user);
    string CreateToken(User user);
}
