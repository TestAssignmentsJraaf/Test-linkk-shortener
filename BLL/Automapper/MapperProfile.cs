using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Automapper;

public class MapperProfile:Profile
{
	public MapperProfile()
	{
		CreateMap<User,UserDTO>();
		CreateMap<CreateUserDTO, User>();
		CreateMap<LoginUserDTO,User>();
		CreateMap<CreateLinkDTO, Link>();	
	}
}
