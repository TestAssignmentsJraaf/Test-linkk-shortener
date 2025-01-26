using BLL.DTO;
using BLL.Services.Base;
using DAL.Entities;

namespace BLL.Services.Interfaces;

public interface ILinkService : ICrud<Link, CreateLinkDTO>
{
    Task<Link> AddAsync(CreateLinkDTO dto, int userId);
}
